package com.example.calculator;
import android.view.View;
import android.widget.TextView;

import org.w3c.dom.Text;


public class ButtonLogics {
    public static void clearCalculator(StringCalculator sc, TextView bigDisplay,TextView smallDisplay){
        bigDisplay.setText("0");
        smallDisplay.setText("");
        sc.clearStringList();
    }

    private static void displayValueInPHone(TextView element, String valueStr){
        element.setText(valueStr);
    }

    public static String outputCorrection(String txt, String tag){

        if (checkForComma(txt) && tag.charAt(0) != ','){
            return txt+tag;
        }
        if (tag.charAt(0) == ',' && !checkForComma(txt)){
            return txt+tag;
        }
        if(tag.charAt(0) == ',' && checkForComma(txt)) return txt;
        return noStartZero(txt)+tag;
    }

    private static boolean checkForComma(String txt){
        for (int i = 0; i < txt.length(); i++){
            if(txt.charAt(i) == ',') return true;
        }
        return false;
    }

    private static  String noStartZero(String txt){
        if (txt.charAt(0) == '0'){
            txt = txt.substring(1);
        }
        return txt;
    }

    public static void equalsHandler(TextView big, TextView small, StringCalculator sc){
        sc.addToStringList(big.getText().toString(), "");
        displayValueInPHone(small, sc.toString());
        small.append("= ");
        sc.calculateStringList();
        displayValueInPHone(big, sc.toString().trim());
        sc.clearStringList();
    }

    public static void operationHandler(TextView big, TextView small, StringCalculator sc, String tag){
        sc.addToStringList(big.getText().toString(), tag);
        displayValueInPHone(big, "0");
        displayValueInPHone(small, sc.toString());
    }
}
