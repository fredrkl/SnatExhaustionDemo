# SnatExhaustionDemo
Demo showing how you can run into a SNAT exhausion if one of your applications is not reusing sockets in AKS.

# Topology
This demo has a very simple setup. X number of consumers are making http requests to the demo application in our K8s cluster. The requests hit the public load balanser that AKS has provisioned to us by the applications K8s Service of type Load Balanser. In a non-demo environment you would typically use an ingress controller instead of exposing the application directly. The demo application is making an outbound request to an external application, in our demo an Azure Function.
![SnatExhaustionDemo Topology](SnatExhaustionDemo.png)

# Endpoints
The application consist of 2 endpoints that you can see on the SnatdemoController.cs. One is using the httpclientfactory to get a new http client but with correct reusing of the underlying sockets. The other is creating a new HttpClient with a belonging socket, resulting in port exchaustion during heavy load.

# Get up and running
This application needs an external endpoint in Azure Function. Create an Azure function and fill in the secret in deploy.yaml. Run kubectl apply -f deploy.yaml in an AKS cluster with Linkerd installed.

You will also need some kind of load testing tool to generate traffic. There are 2 [K6](https://k6.io/) scripts in the LoadTestScripts. Log in to your account, update the projectID in the scripts, the endpoint IP that you got from deploying the application to K8s and run the scripts.