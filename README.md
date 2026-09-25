# Empty NuGet package ID fixture

This is an intentionally broken .NET project for SonarQube Cloud automatic-analysis testing.

The first `PackageReference` has an empty `Include` value. AutoScan.NET reads it and NuGet throws `ArgumentException` (`id` cannot be null or empty). The resolver should log the error, emit a `NuGetResolutionErrorCount` metric with `Reason=ArgumentException`, skip that reference, resolve `Newtonsoft.Json`, and complete analysis.

The application code is otherwise real and uses `Newtonsoft.Json`. A normal `dotnet restore` or `dotnet build` is expected to fail because the empty reference is deliberate; use automatic analysis to exercise the continuation behavior.
