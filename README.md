# Performance Benchmarks on NodeJs, NestJs and DotNet Core
3 simple Web Api Projects: nodeapi (using express), nestapi (using Fastify server) and dotnetapi.
The Api endpoint builds a n number items list and returns the list

The Api End Points are: 
http://localhost:5005/dotnet/:n
http://localhost:5006/node/:n
http://localhost:5007/nest/:n

where n can be any number.

# Performance Bechmark testing using wrk {https://github.com/wg/wrk}
```bash
  # running 10 threads 200 connections for 30 sec, get a simple 1000 items list
  wrk -t10 -c200 -d30s http://localhost:5005/dotnet/1000
  wrk -t10 -c200 -d30s http://localhost:5006/node/1000
  wrk -t10 -c200 -d30s http://localhost:5007/nest/1000
  
  # you can change the n to any number to simulate the length of the tasks 
  # running on the server to see how it affect the load performance 
```

# Benchmark Result

## .Net Core
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

## NodeJs
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

## Nest + Fastify
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


