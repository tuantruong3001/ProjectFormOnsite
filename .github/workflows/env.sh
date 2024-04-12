#!/bin/bash

function replace_values() {
  local file_url=$1
  # replace value

  sed -i "s|\"ApiKey\": \".*\"|\"ApiKey\": \"${{ env.AZURE_APIKEY }}\"|g" "$file_url"

  echo $AZURE_APIKEY | sed 's/./& /g'

  cat "$file_url"
}

replace_values ./appsettings.json
