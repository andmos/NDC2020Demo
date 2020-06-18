NDC 2020 Demo
===

OpenFaaS demo material for my NDC Oslo 2020 and Bekk sommerfagdag lightning talk.

```shell
faas-cli template store pull csharp-kestrel
faas-cli up -f bikeshare-function.yml
curl -d "ilaparken" http://127.0.0.1:8080/function/bikeshare-function |jq
```
