package com.example.shawn.myapplication;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.gashplus.gps.security.cryptography.Crypt3Des;
import com.gashplus.gps.transaction.Trans;

import java.util.HashMap;
import java.util.Map;



public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("GOTO", new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Log.v("GASH", "HAAAAAAAA");

                                TestGash();
                            }
                        }).show();
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    private void TestGash()
    {
        Crypt3Des des;

        String key = "AlLXSFnD9zFmHExmbqOGhNvYoJ/ZrEw+";
        String iv = "bg4sFFjbPfM=";
        String pwd = "dryjwertwessd";
        String cid = "C005580000855";

        Trans trans = new Trans();
        trans.setKey(key);
        trans.setIv(iv);
        trans.setPwd(pwd);

        Log.d("GASH", trans.getErpc("C000030000080", "CP20111206183713", "GP11120620000009", "TWD", "50", "0000"));

        trans.putNode("MSG_TYPE", "0100");
        trans.putNode("PCODE", "300000");
        trans.putNode("CID", cid);
        trans.putNode("CUID", "TWD");
        trans.putNode("PAID", "COPGAM05");
        trans.putNode("AMOUNT","0");
        trans.putNode("ORDER_TYPE","M");
        trans.putNode("ORDER_TYPE","M");
        trans.putNode("ERP_ID","PINHALL");
        trans.putNode("MID","M1000558");

        trans.generateXmlDoc();

        String xml =  trans.getXMLString();
        Log.d("GASH", trans.getXMLString());
        Log.d("GASH", trans.getNodes().get("CID") );
        Log.d("GASH", trans.formatAmount("12.5") );
        Log.d("GASH", Trans.formatAmount("12") );
        Log.d("GASH", Trans.formatAmount("0.52"));
        Log.d("GASH", trans.getErqc(cid, "CP20111202160840", "TWD", "20", pwd));
        Log.d("GASH", trans.getSendData());

        final String sendData = trans.getSendData();
        final String xmlData  =  trans.getXMLString();

        RequestQueue queue = Volley.newRequestQueue(this);
        //String url = "http://10.0.2.2:3000/gash/order";
        String url = "https://stage-api.eg.gashplus.com/GPSv2/order.aspx";

        StringRequest request  = new StringRequest(Request.Method.POST, url, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                Log.d("GASH", "OHMYGOD It Response!!!!");

                Log.d("GASH", "Response Raw:" + response);

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("GASH","OH MY GOD It anser!!!!" );
                Log.d("GASH", "Error:" + error.getLocalizedMessage());

                Log.d("GASH", "time:" + error.getNetworkTimeMs());
            }
        }){
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {
                Map<String,String> params = new HashMap<>();
                params.put("data", "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KCjxUUkFOUz4KICA8TVNHX1RZUEU+MDEwMDwvTVNHX1RZUEU+CiAgPFBDT0RFPjMwMDAwMDwvUENPREU+CiAgPENJRD5DMDA1NTgwMDAwODU1PC9DSUQ+CiAgPENVSUQ+VFdEPC9DVUlEPgogIDxQQUlEPkNPUEdBTTA1PC9QQUlEPgogIDxBTU9VTlQ+MDwvQU1PVU5UPgogIDxPUkRFUl9UWVBFPk08L09SREVSX1RZUEU+CiAgPEVSUF9JRD5QSU5IQUxMPC9FUlBfSUQ+CiAgPE1JRD5NMTAwMDU1ODwvTUlEPgo8L1RSQU5TPgo=");

                return params;
            }
        };
        queue.add(request);

//        des = new Crypt3Des(key, iv);
//
//        String d;
//
//        d =  "<TRANS>";
//        d += "  <MSG_TYPE>0100</MSG_TYPE>";
//        d += "  <MSG_TYPE>0100</MSG_TYPE>";
//        d += "  <PCODE>300000</PCODE>";
//        d += "  <CID>C000030000069</CID>";
//        d += "  <COID>CP20111202160840</COID>";
//        d += "  <CUID>TWD</CUID>";
//        d += "  <PAID>STRESS01</PAID>";
//        d += "  <AMOUNT>20</AMOUNT>";
//        d += "  <ERQC>xHjox+l0+5+ZAPqhLtoTDA1IcOI=</ERQC>";
//        d += "</TRANS>";
//
//        d = Crypt3Des.base64_encode( d );
//
//        trans = new Trans( d );
//        trans.setKey(key);
//        trans.setIv(iv);
//        trans.setPwd(pwd);
//
//        System.out.println( trans.getXMLString() );
//        System.out.println( trans.getNodes().get("CID") );
//        System.out.println( trans.verifyErpc().toString() );
        System.out.println( trans.getSendData() );
//
//        try{
//            System.out.println( "==" + Crypt3Des.base64_encode( des.encrypt("testtest") )  );
//        }catch(Exception ex){}

    }
}
