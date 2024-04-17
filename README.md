# Fase1
O jogo que nós ultilizámos é um jogo em monogame, no qual, numa area deserta, dois tanques batalham, balendo o outro de forma a tentar vencer, sendo que o jogador só pode controlar um dos tanques.



# Grupo
Maria Deolinda Monteiro da Costa nº22530

Margarida Coelho Coimbra do Amaral nº29849



# Imagens do Jogo
![image](https://github.com/theseaweed2005/Fase1/assets/150022513/b2bd7713-fbe3-4aa7-8040-3c49434b9b62)
![image](https://github.com/theseaweed2005/Fase1/assets/150022513/d44ca5cb-8441-4f73-a065-c8621a0a978a)
![image](https://github.com/theseaweed2005/Fase1/assets/150022513/3381b8d6-0d08-48d7-988c-e0399bce38e8)



# Como jogar
**Controlos de Movimento do Tanque**

W - andar para a frente

A - andar para a esquerda

S - andar para trás

D - andar para a direita

LeftShift - acelerar



**Controlos de Mira**

T - apontar para cima

F - apontar para a esquerda

G - apontar para trás

J - apontar para a direita

Space - disparar



Recursos
Liste os principais recursos do jogo, como modos de jogo, características únicas, etc.
Se houver algum recurso especial, como suporte a mods, multiplayer online, etc., detalhe-os aqui.
Bugs Conhecidos / Problemas Conhecidos
Liste quaisquer bugs ou problemas conhecidos que os jogadores possam encontrar ao jogar o jogo. Se possível, forneça informações sobre como os jogadores podem relatar bugs.


# Estrutura do Código

**Pasta "Camara":** Contém um conjunto de arquivos que implementam diferentes tipos de cameras para serem usadas no jogo MonoGame. 
 * ClsCamera.cs: É uma classe abstrata base que fornece funcionalidades comuns a todas as câmeras, como manipulação de mouse e métodos de atualização.
 * ClsCannonCamera.cs: Implementa uma camera que segue o canhão do tanque, mantendo uma perspectiva fixa em relação ao canhão.
 * ClsGhostCamera.cs: Implementa uma camera "fantasma" que pode ser controlada livremente pelo jogador e não está presa a nenhum objeto específico.
 * ClsSurfaceFollowCamera.cs: Implementa uma camera que segue a superfície do terreno, mantendo uma perspectiva fixa em relação ao terreno.
 * ClsThirdPersonCamera.cs: Implementa uma camera de terceira pessoa que segue o tanque, na perspectiva de terceira pessoa.
 

**Pasta "Collider":** Contém um conjunto de arquivos que implementam uma forma de detetar a colisão com um tanque ou com uma bala. É essencial para detetar o dano feito pela bala e as físicas do jogo perante a colisão com objectos.
* ClsColliderBullet.cs: Esta classe implementa um detector de colisão para uma bala no jogo.
* ClsColliderTanks.cs: Esta classe implementa um detector de colisão entre dois tanques no jogo.

**Pasta "Components":** Contém um conjunto de arquivos que controlam o comportamente de diferentes elementos do jogo como os projéteis, os tanques, os terrenos e os objetos.
* ClsBullet.cs: Controla o movimento e a renderização do projétil lançado pelos tanques.
* ClsObject.cs: Controla a posição e a renderização de objetos do jogo.
* ClsTank.cs: Controla o movimento, a rotação, o disparo de projéteis e a renderização do tanque.
* ClsTerrain.cs: Cria a geometria do terreno a partir de um mapa de altura e controla a renderização do mesmo.

**Pasta "Contents":** Contém arquivos de som e de imagem implementados no jogo.

**Pasta "Effects":** 

**Pasta "Managers":** 

Arquivo "Game1.cs": 

Arquivo "Program.cs": 


Créditos
Agradeça a todos os envolvidos no desenvolvimento do jogo. Isso pode incluir desenvolvedores, artistas, músicos e qualquer outra pessoa que tenha contribuído para o projeto.

Licença
Declare a licença do jogo. Isso pode ser importante para os jogadores que desejam modificar ou distribuir o jogo.

Contato
Forneça informações de contato para os jogadores entrarem em contato caso tenham perguntas, sugestões ou relatem problemas.
