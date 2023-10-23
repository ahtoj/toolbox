# toolbox

Selection of tools

# DotnetLambdaSolution1
~~~
dotnet new --install Amazon.Lambda.Templates
dotnet tool install -g Amazon.Lambda.Tools
dotnet new lambda.image.EmptyFunction --name MyFunction1 --region eu-west-1
cd MyFunction1/src/MyFunction1/
dotnet tool install -g Amazon.Lambda.Tools
aws iam create-role --role-name my-dotnet-lambda-role1 --assume-role-policy-document '{"Version": "2012-10-17","Statement": [{ "Effect": "Allow", "Principal": {"Service": "lambda.amazonaws.com"}, "Action": "sts:AssumeRole"}]}'
aws iam attach-role-policy --role-name my-dotnet-lambda-role1 --policy-arn arn:aws:iam::aws:policy/service-role/AWSLambdaBasicExecutionRole
dotnet lambda deploy-function MyFunction1 --function-role my-dotnet-lambda-role1

dotnet lambda invoke-function MyFunction1 --payload "Testing the function"

dotnet lambda delete-function MyFunction1
~~~
