# Exerc�cio 01 - Testes Unit�rios
Crie um novo projeto do tipo ClassLibrary, utilizando o framework .Net de sua prefer�ncia, onde ser� constru�do 
um sistema de urna eletr�nica.
O sistema deve realizar a elei��o de prefeito de uma cidade. 

As seguintes classes e m�todos devem ser criadas: 

## Classe Candidato: (Nome, Votos)

- Construtor
- Adicionar voto
- Retornar votos

## Classe Urna: (Vencedor, VotosVencedor, Candidatos, EleicaoAtiva)

- Construtor
- Resultado da elei��o
- Cadastro de candidato
- Iniciar/Finalizar elei��o

**Crie um novo projeto, na mesma Solution do projeto da urna eletr�nica, do tipo xUnit Test. Nesse projeto, fa�a:**

Para a classe Candidato, crie primeiro os testes utilizando TDD. Construa os seguintes cen�rios de teste:

- Validar se a quantidade de votos est� correta ap�s o cadastro do candidato e ap�s a inser��o de um novo voto
- Validar se o nome do candidato est� correto ap�s o cadastro do candidato

Para a classe Urna, utilize o c�digo dos m�todos j� prontos e construa os seguintes cen�rios de teste:

- Validar se o construtor est� inserindo os dados iniciais corretamente
- Validar se a elei��o est� sendo iniciada/encerrada corretamente
- Validar se, ao cadastrar um candidato, o �ltima candidato na lista � o mesmo que foi cadastrado
- Validar o m�todo de vota��o quando � informado um candidato n�o cadastrado
- Validar o m�todo de vota��o quando � informado um candidato cadastrado
- Validar o resultado da elei��o

## Nos testes, utilize [Fact] ou [Theory] onde julgar necess�rio. Ao terminar, suba o fonte no seu pr�prio Github e envie o link no canal #temp-testes-unitarios-exerc01 no Discord. Ser�o consideradas as entregas realizadas at� o dia 29/09 �s 23:59.