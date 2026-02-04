# Teste_GlobalThings
Criado para guardar resolucoes do teste GT.

#### Observacao
Todos os Codigos estao dentro do projeto -> Teste_GlobalThings_Code

***

### Parte 1

#### A

Seria Criado um endPoint em uma api, com um metodo POST em lote. Considerando
que o equipamento gateway que recebe as informacoes armazena e depois envia os dados,
a API seria capaz de receber uma lista de medições feitas em um periodo de tempo, e nao 
um por vez, otimizando então o trafego de dados entregues ao endpoint.

#### B

MedicaoSensor.cs
MedicaoController.cs


#### C

O melhor banco de dados para guardar do lado do endpoit da API seria um banco de dados
NoSQL, (exemplo MongoDB, Cassandra), pois a velocidade de banco de dados não relacionais
sao mais performaticos para escrita do que os relacionais(SQL, Postgress). Isto é, os dados
gerados em alta velocidade e em grande volume, seriam guardados com menor probabilidade de ter
gargalos em um banco de dados NoSQL.

---

### Parte 2 

#### A
VinculoRequisicao.cs
VinculoController.cs

#### B
Usando Linq:
MedicaoService.cs

---

### Parte 3

#### A
Utilizaria um sistema backend ( WorkerService ), que ficaria uptime o tempo todo.
Este serviço em segundo plano seria para processar as regras de alerta de forma 
assincrona, garantindo que a API de recepcção de dados continue rapida.
Eventuamente, estudaria o caso de fazer uma fila SQS, na AWS caso seja
uma das premissas colocar em cloud o sistema.

#### B

AlertaService.cs

#### C

AlertaServiceTestes.cs

---

### Parte 4

O Problema que enfrentamos esta relacionado ao gargalo de processamento sincrono,
se a API tenta validar as regras de negocio no mentomento que recebe os dados,
temos uma limitacao de banco de daos e processamento(CPU).

Uma solucao possivel seria separar o recebimento do processamento, assim
a API recebiria o dado do sensor e colocaria em uma fila ( RabbitMQ, SQS etc). Assim
A API ficaria livre para receber muitas requisocoes e os Workers( Consumidores), 
processariam as filas na velocidade que o banco de dados aguentaria.

Uma outra Solucao seria uma Insercao em Lote, fazendo um insert no banco de dados de um
agrupamento de medicoes.

***