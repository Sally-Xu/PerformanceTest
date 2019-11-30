## Test on Azure App Services
Both .Net Core App and NodeJs App are deployed to Azure App Services

### NodeJs Api
```
wrk -t10 -c200 -d30s https://nodeapixxx.azurewebsites.net/node/1000    
Running 30s test @ https://nodeapixxx.azurewebsites.net/node/1000
  10 threads and 200 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   880.97ms  217.60ms   1.83s    72.79%
    Req/Sec    23.45     14.21    80.00     60.18%
  6241 requests in 30.09s, 60.89MB read
  Socket errors: connect 0, read 0, write 0, timeout 30
Requests/sec:    207.41
Transfer/sec:      2.02MB

wrk -t10 -c100 -d30s https://nodeapixxx.azurewebsites.net/node/10000  
Running 30s test @ https://nodeapixxx.azurewebsites.net/node/10000
  10 threads and 100 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency     1.42s   449.95ms   2.00s    68.29%
    Req/Sec     4.35      4.32    30.00     65.22%
  707 requests in 30.09s, 78.30MB read
  Socket errors: connect 0, read 0, write 0, timeout 584
Requests/sec:     23.50
Transfer/sec:      2.60MB

wrk -t10 -c100 -d30s https://nodeapixxx.azurewebsites.net/node/100  
Running 30s test @ https://nodeapixxx.azurewebsites.net/node/100
  10 threads and 100 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   103.25ms   47.64ms 483.03ms   86.38%
    Req/Sec    98.61     19.76   202.00     73.33%
  28854 requests in 30.08s, 60.18MB read
  Non-2xx or 3xx responses: 21975
Requests/sec:    959.25
Transfer/sec:      2.00MB
```

### .Net Core Api on Azure App Service
```
wrk -t10 -c200 -d30s https://dotnetapixxx.azurewebsites.net/dotnet/1000
Running 30s test @ https://dotnetapixxx.azurewebsites.net/dotnet/1000
  10 threads and 200 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   602.08ms  343.21ms   1.99s    69.59%
    Req/Sec    26.27     15.26   101.00     63.09%
  7117 requests in 30.11s, 69.46MB read
  Socket errors: connect 0, read 0, write 0, timeout 277
Requests/sec:    236.40
Transfer/sec:      2.31MB

wrk -t10 -c100 -d30s https://dotnetapixxx.azurewebsites.net/dotnet/10000
Running 30s test @ https://dotnetapixxxazurewebsites.net/dotnet/10000
  10 threads and 100 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency     1.49s   411.46ms   2.00s    63.64%
    Req/Sec     4.36      4.18    20.00     66.46%
  729 requests in 30.07s, 80.04MB read
  Socket errors: connect 0, read 0, write 0, timeout 586
Requests/sec:     24.24
Transfer/sec:      2.66MB

wrk -t10 -c100 -d30s https://dotnetapixxx.azurewebsites.net/dotnet/100  
Running 30s test @ https://dotnetapixxx.azurewebsites.net/dotnet/100
  10 threads and 100 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   108.08ms   78.82ms   1.08s    95.88%
    Req/Sec   101.90     26.11   280.00     73.27%
  28641 requests in 30.10s, 33.21MB read
Requests/sec:    951.38
Transfer/sec:      1.10MB
```

### .Net Core Api on AWS
```
wrk -t10 -c200 -d30s https://app-preview.xxx/api/v2/loadtest/1000
Running 30s test @ https://app-preview.xxx/api/v2/loadtest/1000
  10 threads and 200 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   798.55ms  390.35ms   1.99s    72.54%
    Req/Sec    20.02     12.57    90.00     80.15%
  5347 requests in 30.10s, 66.92MB read
  Socket errors: connect 0, read 0, write 0, timeout 288
Requests/sec:    177.65
Transfer/sec:      2.22MB

https://app-preview.xxx/api/v2/loadtest/10000
Running 30s test @ https://app-preview.xxx/api/v2/loadtest/10000
  10 threads and 100 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   730.31ms  302.59ms   1.04s    65.52%
    Req/Sec     4.98      7.60    30.00     91.67%
  62 requests in 30.10s, 10.89MB read
  Socket errors: connect 0, read 0, write 0, timeout 33
Requests/sec:      2.06
Transfer/sec:    370.48KB

wrk -t10 -c100 -d30s https://app-preview.xxx/api/v2/loadtest/100  
Running 30s test @ https://app-preview.xxx/api/v2/loadtest/100
  10 threads and 100 connections
  Thread Stats   Avg      Stdev     Max   +/- Stdev
    Latency   289.47ms  317.42ms   1.52s    81.73%
    Req/Sec    79.78     29.43   181.00     81.81%
  15237 requests in 30.09s, 20.07MB read
Requests/sec:    506.42
Transfer/sec:    682.98KB

```


