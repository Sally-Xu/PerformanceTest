## Performance Benchmark Test on Web API build with NodeJs (pure JavaScript), NestJs (TypeScript Framework) and ASP.Net Core
3 simple Web Api Projects: 
nodeapi (using NodeJs with express server, https://docs.nestjs.com/
nestapi (using NestJs + Fastify server, https://docs.nestjs.com/)
dotnetapi  (using ASP.Net Core, https://docs.microsoft.com/en-us/dotnet/core/about)

The testing Api simply builds a List contains n number strings and returns the list

The Api End Points are: 
DotNetApi: http://localhost:5005/dotnet/{:n}
NodeApi: http://localhost:5006/node/{:n}
NestApi: http://localhost:5007/nest/{:n}

## Steps to Perform the Test
1) Clone the Project

1) Run the dotnet api
```
# cd to PerformanceTest folder
cd PerformanceTest
cd dotnetapi
dotnet restore
dotnet build
dotnet run
```
hit http://localhost:5005/dotnet/1000 on a browser to check if the api is running

3) Run the nodejs api
```
cd PerformanceTest
cd nodeapi
npm install
npm run start
```
hit http://localhost:5006/node/1000 on a browser to check if the api is running

4) Run the nestjs api
```
cd PerformanceTest
cd nestapi
npm install
npm run start:prod
```
hit http://localhost:5007/nest/1000 on a browser to check if the api is running

5) Run Bechmark test using wrk benchmarking tool {https://github.com/wg/wrk}
```bash
  # running 10 threads 200 connections for 30 sec, get a simple 1000 items list
  wrk -t10 -c200 -d30s http://localhost:5005/dotnet/1000
  wrk -t10 -c200 -d30s http://localhost:5006/node/1000
  wrk -t10 -c200 -d30s http://localhost:5007/nest/1000
  
  # you can change the n to any number to simulate the length of the tasks 
  # running on the server to see how it affect the load performance 
```

## Benchmark Result

### ASP.Net Core
```
wrk -t10 -c200 -d30s http://localhost:5005/dotnet/1000
Running 30s test @ http://localhost:5005/dotnet/1000
  10 threads and 200 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency     9.38ms    8.98ms 212.91ms   96.99%
    Req/Sec     2.36k   254.53     3.48k    78.37%
  704577 requests in 30.08s, 6.60GB read
  Socket errors: connect 0, read 63, write 0, timeout 0
Requests/sec:  23425.33
Transfer/sec:    224.56MB
```

### NodeJs
```
wrk -t10 -c200 -d30s http://localhost:5006/node/1000  
Running 30s test @ http://localhost:5006/node/1000
  10 threads and 200 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency    25.98ms    3.51ms 122.33ms   92.37%
    Req/Sec   774.06     70.96     0.88k    90.27%
  231332 requests in 30.05s, 2.18GB read
  Socket errors: connect 0, read 28, write 14, timeout 0
Requests/sec:   7699.00
Transfer/sec:     74.21MB
```

### Nest + Fastify
```
wrk -t10 -c200 -d30s http://localhost:5007/nest/1000
Running 30s test @ http://localhost:5007/nest/1000
  10 threads and 200 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency    26.25ms    3.90ms  92.63ms   87.20%
    Req/Sec   765.50     79.72     2.06k    81.10%
  228959 requests in 30.10s, 2.14GB read
Requests/sec:   7606.28
Transfer/sec:     72.83MB
```
## Conclusion
Under the same condition and same code:

** | NodeJs | Nest | .Net Core
--- | ---: | ---: | ---:
*Requests Served* | 231332 | 228959 | 704577
*Req/sec* | 7699 | 7606 | 23425
*Transfer/sec* | 74.21MB | 72.83MB | 224.56MB

ASP.Net Core has the best performance out of 3, almost 3 times beter.
Nestjs (with Fastify) has the comparible performance with Nodejs (pure JavaScript, with Express). But Nestjs provides structure to write cleaner code.    

