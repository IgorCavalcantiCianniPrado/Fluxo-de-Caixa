# Fluxo de Caixa
Projeto que tem como objetivo realizar um projeto de Fluxo de Caixa de um tipo de empório. 

A ideia neste case é basicamente (considerando as instruções do mesmo e minha "liberdade de criação") ter um sistema básico de um empório que vende Cervejas e Vinhos, de maneira que eu registro cada lançamento realizado como um Crédito (venda, que resulta em entrada de dinheiro) ou como um Débito (compra, que resulta em saída de dinheiro).

Obs.: há uma simplicidade nos conceitos pela limitação de tempo e obviamente pelo caráter fictício do case. 


# Arquitetura do Case
![image](https://github.com/IgorCavalcantiCianniPrado/CaseMttechne/assets/86272097/fa2e5b41-3634-409c-b825-7d152d146199)

A ideia aqui é basicamente a seguinte: eu posso postar um lançamento de crédito ou débito na api **Fluxo de Caixa**. Como lançamentos deste tipo não precisam geralmente de uma atualização instantânea (e em um caso real haveriam muitos lançamentos simultâneos), decidi fazer isso de forma assíncrona utilizando um Message Broker para controlar esse tráfego de mensagens. Após háver mensagens a serem consumidas, o **Serviço Worker** se encarrega disso, e após este consumo ele registra a mensagem no Banco de Dados. Em relação ao **Relatório de Saldo Consolidado**, é preciso haver um comportamento síncrono, então não uso nenhum intermediário entre a api de relatório e o banco de dados, fazendo o cálculo de saldo e retornando imediatamente para o usuário. 

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

No endereço com a porta 5000, realize a autenticação (usuário: IgorPrado, senha:123456):

![image](https://github.com/IgorCavalcantiCianniPrado/CaseMttechne/assets/86272097/25c69591-9f4c-4994-a306-ae11e9c620ad)
 
E use o seguinte endpoint:

![image](https://github.com/IgorCavalcantiCianniPrado/CaseMttechne/assets/86272097/60c4e9f2-9d36-4e44-8496-c460f52dd37e)

No endereço com a porta 5001, realize a autenticação (usuário: IgorPrado, senha:123456):

![image](https://github.com/IgorCavalcantiCianniPrado/CaseMttechne/assets/86272097/f9a43e6e-13ce-440a-acfa-23ea97659de0)

E use o seguinte endpoint:

![image](https://github.com/IgorCavalcantiCianniPrado/CaseMttechne/assets/86272097/e0e69a65-695a-4ce1-97ce-f2dcb974f854)

**Obs.: Para se visualizar com mais detalhes os dados dos produtos fictícios, verifique os registros no banco de dados MongoDB utilizado. Você verá registros parecidos com o seguinte:**

![image](https://github.com/IgorCavalcantiCianniPrado/CaseMttechne/assets/86272097/0efa1079-8c04-49b0-848c-c8d293ecb686)
