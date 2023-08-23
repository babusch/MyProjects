package com.example.calculator;

import org.w3c.dom.DOMStringList;

import java.util.ArrayList;
import java.util.List;

public class StringCalculator {
    private List<String> stringList = new ArrayList<String>();

    public void addToStringList(String number, String operation){
        stringList.add(number);
        if (!operation.equals("")) stringList.add(operation);
    }

    public void calculateStringList(){
        commaToDotInList();
        while (scanForOperation(stringList, "^"));
        while (scanForOperation(stringList, "*"));
        while (scanForOperation(stringList, "/"));
        while (scanForOperation(stringList, "-"));
        while (scanForOperation(stringList, "+"));
    }

    private void commaToDotInList(){
        for (int i = 0; i < stringList.size(); i++){
            stringList.set(i, commaToDot(stringList.get(i)));
        }
    }

    private String commaToDot(String str){
        return str.replace(',', '.');
    }

    private boolean scanForOperation(List<String> arrayList, String operation){
        int index = arrayList.indexOf(operation);
        if(index >= 0){
            arrayList.set(index-1, calculateOperation(arrayList, index, operation));
            clearInFrontInBackIndex(arrayList, index);
            return true;
        }
        return false;
    }

    private void clearInFrontInBackIndex(List<String> arrayList, int index){
        arrayList.remove(index+1);
        arrayList.remove(index);
    }

    private String calculateOperation(List<String> arrayList, int index, String operationLocal){
        double x = Double.parseDouble(arrayList.get(index-1).toString());
        double y = Double.parseDouble(arrayList.get(index+1).toString());
        double result = 0;
        if (operationLocal.equals("*")) result = Operation.Mul(x,y);
        if (operationLocal.equals("/")) result = Operation.Div(x,y);
        if(operationLocal.equals("-")) result = Operation.Sub(x,y);
        if (operationLocal.equals("+")) result = Operation.Add(x,y);
        if (operationLocal.equals("^")) result = Operation.Pow(x,y);
        return String.valueOf(result);
    }

    public void clearStringList(){
        stringList.clear();
    }

    @Override
    public String toString(){
        return convertStringList();
    }

    private String convertStringList(){
        String str = "";
        for (int i = 0; i < stringList.size(); i++){
            str += organizingDoubleString(stringList.get(i))+" ";
        }
        str = str.replace('.',',');
        return str;
    }

    private String organizingDoubleString(String str){
        String number = str;
        for (int i = 0; i < number.length(); i++){
            if(number.charAt(i) == '.'){
               number = checkZeroSpam(number, i);
               break;
            }
        }
        return number;
    }

    private String checkZeroSpam(String number, int i){
        for (int j = i+1; j<number.length(); j++){
            if (number.charAt(j) != '0') {
                return number;
            }
        }
        number = number.substring(0,i);
        return number;
    }
}
