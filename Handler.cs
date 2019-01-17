using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Linq;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]


namespace AwsDotnetCsharp
{
    public class Handler
    {
       public APIGatewayProxyResponse Hello(APIGatewayProxyRequest request, ILambdaContext context)
      {
          Calculator sum = new Calculator();

          List<int> values = request.QueryStringParameters.Values.Select(item => int.Parse(item)).ToList();
          
          string result = new String("");

          if( values.Count() > 0){

            foreach (int item in values)
            {
                sum.sum(item);
            }

            result = JsonConvert.SerializeObject(sum);

          }else{

            result = "{\"message\":\"Nenhum argumento informado.\"}";

          }


          APIGatewayProxyResponse response = new APIGatewayProxyResponse
          {
              StatusCode = (int)HttpStatusCode.OK,
              Body = result,
              Headers = new Dictionary<string, string> {{ "Content-Type", "application/json" }}
          };

          return response;
      }

        public APIGatewayProxyResponse Subtract(APIGatewayProxyRequest request, ILambdaContext context)
        {
          Calculator calculator = new Calculator();

          List<int> values = request.QueryStringParameters.Values.Select(item => int.Parse(item)).ToList();
            
          string result = new String("");

          if( values.Count() < 2 ){

              result = "{\"message\":\"São necessários dois argumentos. Apenas um argumento informado.\"}";
          
          }else if( values.Count() > 2 ){
          
              result = "{\"message\":\"São necessários dois argumentos. Mais de dois argumentos foram informados.\"}";
          
          }else{
          
              calculator.subtract(values[0], values[1]);
          
              result = JsonConvert.SerializeObject(calculator);
          }

          APIGatewayProxyResponse response = new APIGatewayProxyResponse
          {
              StatusCode = (int)HttpStatusCode.OK,
              Body = result,
              Headers = new Dictionary<string, string> {{ "Content-Type", "application/json" }}
          };

          return response;
        }
      
    }

    public class Calculator
    {
      public float result {get;set;}

      public void sum(float value){
        result = result+value;
      }

      public void subtract(float value1, float value2){
        result = value1-value2;
      }


      public void multiply(float value1, float value2){
        result = value1*value2;
      }

      public void devide(float valeu1, float value2){
          result = valeu1/value2;
      }

      public Calculator(){
        result = 0;
      }
    }
}
