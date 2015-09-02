

var CurrentValue=0;
var ExistCurrValu = false;
var ClearedCalcSrtr = false;
var IsEqualPres = false;
var LastArithemikSymol="";
var lustButtonValu= 0;

//exept memory battons and erase batton
var lastPressedButton;



function GetCalcValu()
{
  var val = document.getElementById("CalcStr").value;
  var ReversVal ="";
    
    for (var i=0;i<val.length;i++)
        ReversVal+=val[val.length - 1 - i];
    
    return  ReversVal;
}


function SetCalcValu(val)
{
    var ReversVal ="";
    var strVal = String(val);
    
     for (var i=0;i<strVal.length;i++)
        ReversVal+=strVal[strVal.length - 1 - i];
    
   document.getElementById("CalcStr").value = ReversVal;
}



function ButtonClick(obj)
{


    
    if(!isNaN(obj.value))
    {
        NumberWriter(obj);
        lastPressedButton = obj.value;   
    }
    
    if (obj.classList[1]==="math" && GetCalcValu!=="")
    {
        MathOperation(obj);
        lastPressedButton = obj.value;
    }
    
    if (obj.classList[1]==="strOp" )
    {
        StringOperation(obj.value);
        
    }
    
    if (obj.classList[1]==="equal" )
    {
        lastPressedButton = obj.value;
        EqualOperation();
    }
    
    if (obj.classList[1]==="memoryOp" )
    {
        MemoryOperation(obj.value);
    }
    
    
    
}

function NumberWriter(obj)
{

    if(IsEqualPres)
    {
        SetCalcValu("");
        //LastArithemikSymol="";
        IsEqualPres = false;
    }
    
     if (ExistCurrValu)  
        {
            if (!ClearedCalcSrtr)
            {
                 SetCalcValu("");
                 ClearedCalcSrtr = true;
            }
           
        }

     lustButtonValue = obj.value;
     var str  = GetCalcValu();
     SetCalcValu( str + obj.value);

}

 function MathOperation(obj)
{
 if (lastPressedButton ==='*' || lastPressedButton==='/' || lastPressedButton === '+' || lastPressedButton==='-' || lastPressedButton === '%')
 {
  LastArithemikSymol = obj.value;
     return;
 }
    
    
    if (ExistCurrValu)
    {
        var NewCalcValu = GetCalcValu();
      SetCalcValu( Calculate(CurrentValue,NewCalcValu,LastArithemikSymol));
    }
    
  CurrentValue = GetCalcValu();
  ExistCurrValu = true;
  ClearedCalcSrtr = false;      
  LastArithemikSymol = obj.value;
     
}


function Calculate(num1,num2,operation)
{
    var res;
  switch (operation)
  {
      case '*' :
        res =  num1*num2;    
      break;
              
      case "/":
        res = num1/num2;     
      break;
              
      case "-":
        res = num1-num2;     
      break;
            
      case "+":
         res =  +num1 + +num2;     
      break;
              
      case "%":
        res = num1%num2;
      break;
              
  }
            return res; 
}

function  StringOperation(operation)
{
 
     switch (operation)
  {
      case '+/-' :
        SetCalcValu(0 - GetCalcValu());
        CurrentValue;
      break;
              
      case ".":
        SetPoint();    
      break;
     
      case "C":
        ResetCalc();    
      break;
    
              
      case "<--":
          var calcValue = GetCalcValu();
        SetCalcValu(calcValue.substring(0,calcValue.length-1));    
      break;
                          
  }
    
    
}

function SetPoint()
{
  var CalcValu = GetCalcValu();
    
  var PointIndex = CalcValu.indexOf('.');
    
    if(PointIndex === -1)
        SetCalcValu(CalcValu+'.');
    
}

 function EqualOperation()
{
  
    if (!IsEqualPres)
    {
       
        var res = Calculate(CurrentValue,GetCalcValu(),LastArithemikSymol);
        
        if(!isNaN(res))
        {
            SetCalcValu(res);
            CurrentValue=0;
            ExistCurrValu = false;
            ClearedCalcSrtr = false;
            IsEqualPres = true;
            
        }

    }
    
   else 
   {
     SetCalcValu(Calculate(GetCalcValu(),lustButtonValue,LastArithemikSymol));
       
   }
     
  
    
}

    function ResetCalc()
    {
        CurrentValue=0;
        ExistCurrValu = false;
        ClearedCalcSrtr = false;
        IsEqualPres = false;
        LastArithemikSymol="";
        lustButtonValue=0;
         lastPressedButton="";
        SetCalcValu("");
    }

function MemoryOperation(operation)
{
    
      switch (operation)
   {
      case 'M+' :
        document.getElementById("MemStr").value = GetCalcValu();
        IsEqualPres = true;
      break;
              
      case "MC":
         document.getElementById("MemStr").value = "";  
      break;
     
      case "MR":
        SetCalcValu( document.getElementById("MemStr").value);    
      break;
                
   }
    
}

