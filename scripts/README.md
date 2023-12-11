# DNIT UPDATER

Módulo responsável pelo deploy contínuo dos serviços. Para isso acontecer, quando um Pull Request é fechado, é ativado a pipeline de deploy `.github/workflows/deploy.tml` que builda o projeto e envia para um webhook.
O serviço de atualização se encontra no arquivo `dnit_updater.py` e um aplicação web em FastApi que espera o arquivo do novo build, realiza o versionamento, e atualiza o processo do serviço em executação.

## Pacote
O updater foi empacotado para ser reutilizado nos outros serviços e esta disponível no Pypi: https://pypi.org/project/dnit_updater/
