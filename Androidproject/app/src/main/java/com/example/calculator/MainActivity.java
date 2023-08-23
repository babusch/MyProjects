package com.example.calculator;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;


public class MainActivity extends AppCompatActivity {
    StringCalculator stringCalculator = new StringCalculator();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void onBtnNumberClick(View view){
       numberInputHandler(view.getTag().toString());
    }

    public void onBtnOperationClick(View view){
        operationInputHandler(view.getTag().toString());
    }

    public void numberInputHandler(String tag){
        TextView txt = findViewById(R.id.lblBigDisplay);
        txt.setText(ButtonLogics.outputCorrection(txt.getText().toString(), tag));
    }
    public void operationInputHandler(String tag){
        TextView big = findViewById(R.id.lblBigDisplay);
        TextView small = findViewById(R.id.lblSmallDisplay);
        if(tag.charAt(0) == 'c'){
            ButtonLogics.clearCalculator(stringCalculator, big, findViewById(R.id.lblSmallDisplay));
            return;
        }
        if(tag.charAt(0) == '='){
           ButtonLogics.equalsHandler(big, small, stringCalculator);
            return;
        }
        ButtonLogics.operationHandler(big, small, stringCalculator, tag);
    }


}

/*
    String activeValueStr = "";
    List<String> inputCollection = new ArrayList<String>();
    private void newInputMethod(List<String> arrayList, String str){
        arrayList.add(str);
    }

    private void calculateStringList(List<String> arrayList){
        while (scanForOperation(arrayList, " ^ "));
        while (scanForOperation(arrayList, " * "));
        while (scanForOperation(arrayList, " / "));
        while (scanForOperation(arrayList, " - "));
        while (scanForOperation(arrayList, " + "));
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
        int x = Integer.parseInt(arrayList.get(index-1).toString());
        int y = Integer.parseInt(arrayList.get(index+1).toString());
        int result = 0;
        if (operationLocal.equals(" * ")) result = x * y;
        if (operationLocal.equals(" / ")) result = x / y;
        if(operationLocal.equals(" - ")) result = x - y;
        if (operationLocal.equals(" + ")) result = x + y;
        if (operationLocal.equals(" ^ ")) result = power(x,y);
        return String.valueOf(result);
    }
        private int power(int x, int y){
        if (y == 0){
            return 1;
        }
        return x * power(x,y-1);
    }
      private void displayOperation(char tag){
        if (!activeValueStr.equals("")) newInputMethod(inputCollection, activeValueStr);
        newInputMethod(inputCollection, " "+tag+" ");
        displayValueInPHone(R.id.lblSmallDisplay, inputCollectionElements());
        displayValueInPHone(R.id.lblBigDisplay, "0");
        activeValueStr = "";
    }
       private void equals(char tag){
        newInputMethod(inputCollection, activeValueStr);
        displayValueInPHone(R.id.lblSmallDisplay, inputCollectionElements());
        TextView text = findViewById(R.id.lblSmallDisplay);
        text.append(" "+tag+" ");
        calculateStringList(inputCollection);
        displayValueInPHone(R.id.lblBigDisplay, inputCollection.get(0));
        activeValueStr = "";
    }
     private String inputCollectionElements(){
        String str ="";
        for (int i = 0; i < inputCollection.size(); i++){
            str += inputCollection.get(i);
        }
        return str;
    }
    private void inputNumberHandler(int x){
        activeValueStr += String.valueOf(x);
        displayValueInPHone(R.id.lblBigDisplay, activeValueStr);
    }

    private void displayValueInPHone(int id, String valueStr){
        TextView element = findViewById(id);
        element.setText(valueStr);
    }
       private void newButtonPressed(char tag){
        if (tag == 'c') newClearCalculator();
        if (tag == '='){
            equals(tag);
        }
        if (tag == '+' || tag == '-' || tag == '/' || tag == '*' || tag == '^'){
            displayOperation(tag);
        }
    }
      private void newClearCalculator(){
        displayValueInPHone(R.id.lblBigDisplay, "0");
        displayValueInPHone(R.id.lblSmallDisplay, "");
        inputCollection.clear();
        activeValueStr = "";
    }
       public void onBtnNumberClick(View view){
        inputNumberHandler(Integer.parseInt(view.getTag().toString()));
    }

    public void onBtnOperationClick(View view){
        newButtonPressed(view.getTag().toString().charAt(0));
    }
    */