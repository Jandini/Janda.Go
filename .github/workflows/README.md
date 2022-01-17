The repository must have valid **nuget.org** token stored under **NUGET_ORG_API_KEY** in [Actions secrets (github.com)](https://github.com/Jandini/Janda.Go/settings/secrets/actions) in order to push new package to nuget.org.



**NUGET_AUTH_TOKEN** variable must be set in order to access GitHub packages in private repositories.

```yaml
with:
  dotnet-version: 6.0.x
  source-url: https://nuget.pkg.github.com/${{ github.repository_owner }}/index.json
```







