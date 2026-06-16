#!/usr/bin/env bash
set -euo pipefail

install_autosdk_cli() {
  dotnet tool update --global autosdk.cli --prerelease >/dev/null 2>&1 || \
    dotnet tool install --global autosdk.cli --prerelease
}

# OpenAPI spec: locally maintained (no public spec available)
install_autosdk_cli

rm -rf Generated

# SarvamAI has no public OpenAPI spec — openapi.yaml is manually maintained from docs
# Auth is already set to http/bearer in the spec — no yq fix needed

autosdk generate openapi.yaml \
  --namespace SarvamAI \
  --clientClassName SarvamAIClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations
