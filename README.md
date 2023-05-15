# CaseMttechne
Projeto que tem como objetivo realizar um case técnico da empresa **Mttechne**. 

A ideia neste case é basicamente (considerando as instruções do mesmo e minha "liberdade de criação") ter um sistema básico de um empório que vende Cervejas e Vinhos, de maneira que eu registro cada lançamento realizado como um Crédito (venda, que resulta em entrada de dinheiro) ou como um Débito (compra, que resulta em saída de dinheiro).

Obs.: há uma simplicidade nos conceitos pela limitação de tempo e obviamente pelo caráter fictício do case. 


# Arquitetura do Case
![image](https://github.com/IgorCavalcantiCianniPrado/CaseMttechne/assets/86272097/fa2e5b41-3634-409c-b825-7d152d146199)


# Rodar Localmente o Projeto
Para se rodar localmente este projeto, utilize o arquivo **docker-compose.yml**, executando o seguinte comando no diretório onde se encontra o arquivo:
**docker-compose up**

Após a execução do comando, os seguintes serviços devem ficar de pé:
- **fluxocaixaapiservice** (api para postar os lançamentos de crédito e débito no Message Broker)
- **workerservice** (serviço que consome do Message Broker os lançamentos e registra no Banco de Dados)
- **relatorioservice** (serviço que exibe o saldo atual com base nos lançamentos no Banco de Dados)
- **rabbitmqservice** (Message Broker)
- **mongodbservice** (Banco de Dados)


# Testar o Funcionamento do Sistema
Para se testar o funcionamento do Case técnico, basta utilizar o Swagger nos serviços **fluxocaixaapiservice** e **relatorioservice**. Para isto, considerando a configuração atual de portas do **docker-compose.yml**, abra no seu browser respectivamente os endereços **http://localhost:5000/Swagger** e **http://localhost:5001/Swagger**. 

No endereço com a porta 5000 use o seguinte endpoint:

![image](https://github.com/IgorCavalcantiCianniPrado/CaseMttechne/assets/86272097/60c4e9f2-9d36-4e44-8496-c460f52dd37e)

E no endereço com a porta 5001, use o seguinte endpoint:

![image](https://github.com/IgorCavalcantiCianniPrado/CaseMttechne/assets/86272097/e0e69a65-695a-4ce1-97ce-f2dcb974f854)


