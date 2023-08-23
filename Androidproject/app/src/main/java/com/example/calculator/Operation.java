package com.example.calculator;

public class Operation {
    public static double Add(double x, double y){
        return x+y;
    }

    public static double Sub(double x, double y){
        return x-y;
    }

    public static double Mul(double x, double y){
        return x * y;
    }

    public static double Div(double x, double y){
        return x / y;
    }

    public static double Pow(double x, double y){
        if(y <= 0) return 1;
        return x*Pow(x, y-1);
    }
}
