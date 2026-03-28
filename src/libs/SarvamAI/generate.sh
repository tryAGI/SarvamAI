#!/usr/bin/env bash
set -euo pipefail

dotnet tool install --global autosdk.cli --prerelease

rm -rf Generated

# SarvamAI has no public OpenAPI spec — openapi.yaml is manually maintained from docs
# Auth is already set to http/bearer in the spec — no yq fix needed

autosdk generate openapi.yaml \
  --namespace SarvamAI \
  --clientClassName SarvamAIClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations
