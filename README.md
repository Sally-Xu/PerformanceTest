## Performance Benchmark Test on Web API build with NodeJs (pure JavaScript), NestJs (TypeScript Framework), ASP.Net Core and Python Flask framework
4 simple Web Api Projects:
nodeapi (using NodeJs with express server, https://docs.nestjs.com/
nestapi (using NestJs + Fastify server, https://docs.nestjs.com/)
dotnetapi  (using ASP.Net Core, https://docs.microsoft.com/en-us/dotnet/core/about)
flaskapi
The testing Api simply builds a List contains n number strings and returns the list

The Api End Points are:
DotNetApi: http://localhost:5005/dotnet/{:n}
NodeApi: http://localhost:5006/node/{:n}
NestApi: http://localhost:5007/nest/{:n}
FlaskApi: http://localhost:5008/flask/{:n}

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

5) Run the Flask api
```
cd PerformanceTest
cd flaskapi
python3 src/app.py
```
hit http://localhost:5008/flask/1000 on a browser to check if the api is running

6) Run Bechmark test using wrk benchmarking tool {https://github.com/wg/wrk}
```bash
  # running 10 threads 200 connections for 30 sec, get a simple 1000 items list
  wrk -t10 -c200 -d30s http://localhost:5005/dotnet/1000
  wrk -t10 -c200 -d30s http://localhost:5006/node/1000
  wrk -t10 -c200 -d30s http://localhost:5007/nest/1000
  wrk -t10 -c200 -d30s http://localhost:5008/flask/1000
  # you can change the n to any number to simulate the length of the tasks 
  # running on the server to see how it affect the load performance 
```

7) Run Bechmark test using wrk hitting end point retrieve 10 items from MongoDB
```
  wrk -t10 -c200 -d30s http://localhost:5005/dotnet/data
  wrk -t10 -c200 -d30s http://localhost:5006/node/data
```


## Benchmark Result without Database access

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

### Python Flask
```
wrk -t10 -c200 -d30s http://localhost:5008/flask/1000
Running 30s test @ http://localhost:5008/flask/1000
  10 threads and 200 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   133.12ms   99.04ms   1.13s    97.89%
    Req/Sec   104.01     26.75   202.00     73.37%
  16483 requests in 30.10s, 173.56MB read
  Socket errors: connect 32, read 1063, write 31, timeout 0
Requests/sec:    547.52

```

## Benchmark Result with simple MongoDB Database read

### ASP.Net Core
```
wrk -t10 -c200 -d30s http://localhost:5005/dotnet/data
Running 30s test @ http://localhost:5005/dotnet/data
  10 threads and 200 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency    26.27ms   14.81ms 275.42ms   85.14%
    Req/Sec   798.90     99.69     1.26k    73.50%
  238731 requests in 30.04s, 751.32MB read
Requests/sec:   7947.90
Transfer/sec:     25.01MB
```

### NodeJs
```
wrk -t10 -c200 -d30s http://localhost:5006/node/data
Running 30s test @ http://localhost:5006/node/data
  10 threads and 200 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   130.78ms   36.78ms 269.53ms   67.73%
    Req/Sec   153.13     30.87   242.00     67.36%
  45825 requests in 30.10s, 147.06MB read
  Socket errors: connect 0, read 58, write 0, timeout 0
Requests/sec:   1522.42
Transfer/sec:      4.89MB
```
## Conclusion
### Under the same condition and same code without Database access:

** | NodeJs | Nest | .Net Core | Python Flask
--- | ---: | ---: | ---: | ---:
*Requests Served* | 231332 | 228959 | 704577 | 16051
*Req/sec* | 7699 | 7606 | 23425 | 533.22
*Transfer/sec* | 74.21MB | 72.83MB | 224.56MB | 5.61MB

### Under the same condition and same code with Database access:

** | NodeJs | Nest | .Net Core | Python Flask
--- | ---: | ---: | ---: | ---:
*Requests Served* | 45825 |  | 238731 | 
*Req/sec* | 1522.42 |  | 7947.90 | 
*Transfer/sec* | 4.89MB |  | 25.01MB | 

#### ASP.Net Core has the best performance out of 4, almost 3 times beter when no simple code, 5 time better when retrieve data from database.

#### Nestjs (with Fastify) has the comparible performance with Nodejs (pure JavaScript, with Express). But Nestjs provides structure to write cleaner code.

### Several Considerations
1) Tested with ASP.NET Core V2.2 and V3.1. The results are similar.
2) Turn on https will reduce the performance by 40%
3) All Tests listed in this doc are test from localhost. 
4) All Tests should also be performed on Cloud enviroment as well. See CloudTestReset.md   



