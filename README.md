NDC 2020 Demo
===

OpenFaaS demo material for my NDC Oslo 2020 lightning talk.

```shell
faas-cli template store pull csharp-kestrel
faas-cli up -f bikeshare-providers.yml
curl http://127.0.0.1:8080/function/bikeshare-providers
```
