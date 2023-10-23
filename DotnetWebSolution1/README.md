# core-api

in solution folder:
~~~
docker build .
docker tag <your-image-id> <your-aws-account>.dkr.ecr.eu-west-1.amazonaws.com/toolbox:v0.1.0
aws ecr get-login-password --region eu-west-1 | docker login --username AWS --password-stdin <your-aws-account>..dkr.ecr.eu-west-1.amazonaws.com
docker push <your-aws-account>.dkr.ecr.eu-west-1.amazonaws.com/toolbox:v0.1.0
~~~

run locally:
~~~
docker run -it --rm -p 5000:80 -p 5001:443 -e ASPNETCORE_HTTPS_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 --name aspnetcore_sample <your-aws-account>.dkr.ecr.eu-west-1.amazonaws.com/toolbox:v0.1.2
~~~
or
~~~
cd CoreApi/
dotnet run
~~~


endpoints:
~~~
/
~~~

notes:
~~~
dotnet add package AWSSDK.ECS
~~~
