/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package com.gashplus.gps.common;

/**
 *
 * @author jerryhu
 */
public class Enum {

    public enum RCODE {

        UNDEFINED(-1), //未定義的訊息</DESC></RCODE>
        SUCCESSFUL_APPROVAL_COMPLETION(0), //訊息處理成功</DESC></RCODE>
        SECURITY_CHECK_ERROR(1001), //驗證碼錯誤</DESC></RCODE>
        FORMAT_CHECK_ERROR(1101), //錯誤的訊息格式</DESC></RCODE>
        FORMAT_CHECK_ERROR_PA_CURRENCY(1102), //錯誤的訊息格式(PA幣別錯誤)</DESC></RCODE>
        FORMAT_CHECK_ERROR_XML_CAN_NOT_PARSE(1103), //錯誤的訊息格式(XML無法解析)</DESC></RCODE>
        INVALID_TRANSACTION(1104), //不合法的交易</DESC></RCODE>
        INVALID_AMOUNT(1105), //不合法的金額</DESC></RCODE>
        INVALID_ERP_ITEM(1106), //不合法的ERP商品代碼</DESC></RCODE>
        INVALID_PARAM_MESSAGE_CODE(1107), //不合法的交易訊息代碼或交易處理代碼</DESC></RCODE>
        INVALID_PARAM_RENT(1108), //不合法的月租交易參數</DESC></RCODE>
        FORMAT_CHECK_ERROR_CONTENT_CURRENCY(1109), //錯誤的訊息格式(CONTENT幣別錯誤)</DESC></RCODE>
        INVALID_MERCHANT_OR_BRANCH_OR_CONTENT(1201), //不合法的商家代碼、服務代碼</DESC></RCODE>
        INVALID_MERCHANT(1202), //不合法的商家代碼</DESC></RCODE>
        INVALID_BRANCH(1203), //不合法的平台代碼</DESC></RCODE>
        INVALID_CONTENT(1204), //不合法的服務代碼</DESC></RCODE>
        INVALID_CLIENT_IP(1205), //不合法的網路位址</DESC></RCODE>
        INVALID_PA(1301), //不合法或不存在的付款機構</DESC></RCODE>
        UNABLE_TO_LOCATE_PREVIOUS_MESSAGE(1401), //無法找到原始交易, 例如退訂找不到原始訂單編號</DESC></RCODE>
        DATA_ARE_INCONSISTENT_WITH_ORIGINAL_MESSAGE(1402), //交易內容與原始交易不一致</DESC></RCODE>
        INSUFFICIENT_FUNDS(1501), //額度不足</DESC></RCODE>
        EXCEED_THE_UPPER_AMOUNT(1502), //超過金額上限</DESC></RCODE>
        INVALID_TXTIME(1503), //無效的交易時間</DESC></RCODE>
        INVALID_CONTENT_PA(1504), //不允許使用的付款機構</DESC></RCODE>
        UNENABLED_MERCHANT(1601), //未啟用的商家代碼</DESC></RCODE>
        UNENABLED_BRANCH(1602), //未啟用的平台代碼</DESC></RCODE>
        UNENABLED_CONTENT(1603), //未啟用的服務代碼</DESC></RCODE>
        DISABLED_MERCHANT(1604), //停用的商家代碼</DESC></RCODE>
        DISABLED_BRANCH(1605), //停用的平台代碼</DESC></RCODE>
        DISABLED_CONTENT(1606), //停用的服務代碼</DESC></RCODE>
        DISABLED_PA(1607), //停用的付款機構</DESC></RCODE>
        RE_ENTER_TRANSACTION(2001), //交易重複</DESC></RCODE>
        RE_ENTER_SETTLE(2002), //重複請款</DESC></RCODE>
        SETTLE_NON_ESSENTIAL_EXCEPT_FIRST_PHASE(2003), //月租僅第一期需要請款</DESC></RCODE>
        CAN_NOT_UNPACK_TRANS_DATA(2004), //無法解開交易參數</DESC></RCODE>
        PA_TRANSACTION_CAN_NOT_FINISH(3001), //無法完成付款</DESC></RCODE>
        INVALID_PA_NOT_SUPPOT_RENT_SERVICE(3002), //付款機構不提供月租服務</DESC></RCODE>
        INVALID_PA_JUST_SUPPOT_RENT_SERVICE(3003), //付款機構只提供月租服務</DESC></RCODE>
        PIN_POINT_UNMATCH(3901), //儲值點數不一致</DESC></RCODE>
        PIN_IS_LOCKED(3902), //儲值密碼已鎖定</DESC></RCODE>
        PIN_IS_USED(3903), //儲值密碼已使用</DESC></RCODE>
        SYSTEM_FAIL_TRANS_MESSAGE_ASSIGN(9001), //交易參數無法轉換</DESC></RCODE>
        SYSTEM_FAIL_CAN_NOT_INITIAL_LOG(9002), //無法初始化記錄檔</DESC></RCODE>
        SYSTEM_FAIL_CAN_NOT_INITIAL_TRANS(9003), //無法初始化交易</DESC></RCODE>
        SYSTEM_MALFUNCTION(9999); //系統發生異常</DESC></RCODE>

        private final int _rcode;
        RCODE(int rcode) { this._rcode = rcode; }
        public int getValue() { return _rcode; }

        public static RCODE convert(int rcode){
            try{
                return values()[ rcode ];
            }catch(ArrayIndexOutOfBoundsException e ){
                return UNDEFINED;
            }
        }

        public static String getString(int rcode){
            return convert(rcode).toString();
        }

        public static String getString(RCODE rcode){
            return rcode.toString();
        }
    }

}
