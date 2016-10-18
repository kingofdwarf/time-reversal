/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package com.gashplus.gps.transaction;

import com.gashplus.gps.common.Enum.*;

/**
 * 解析回應訊息
 * @author jerryhu
 * @version 1.0.0
 */
public interface ICodeMessage {

    /**
     * 取得訊息字串
     * @param code GPS 回應之 RCODE
     * @return RCODE 對應之訊息字串
     */
    public RCODE getMessage(int code);

}
