# Fase2
O jogo que nós fizemos é um top-down shotter, no qual o player tem que tentar derrotar os monstros há sua volta.

# Grupo
Maria Deolinda Monteiro da Costa nº22530

Margarida Coelho Coimbra do Amaral nº29849

# Imagens do Jogo
![posição3](https://github.com/theseaweed2005/Fase1/assets/150022513/933182dd-6ed7-4e00-8ef1-abe0aa0bb533)
![progectil](https://github.com/theseaweed2005/Fase1/assets/150022513/53317ffb-4894-4021-a251-3a1074f3095c)
![1](https://github.com/theseaweed2005/Fase1/assets/150022513/03ab4861-4f5c-4060-8c7c-45b9d22487f1)
![background](https://github.com/theseaweed2005/Fase1/assets/150022513/dadba694-ea68-4502-8210-260bfd7ee57a)


# Controlos


**Controlos do teclado**:

* W: Mover para cima
* S: Mover para baixo
* A: Mover para a esquerda
* D: Mover para a direita
* Espaço: trocar de armas (não implementado)

**Controlos do Rato**:
* Movimentos do Rato: Mira a arma do jogador
* Botão Esquerdo do Rato: Disparar a arma
* Botão Direito do Rato: Recarregar a arma

**Outros**:
* Escape: Sair do jogo






# Estrutura do Código

**Classe "Game1.cs":** Esta classe é a classe principal do jogo. Contém os seguintes métodos:
* Initialize: Initializa as definições do jogo como o tamanho da janela do jogo;
* LoadContent: Carrega conteúdo como textura e sprites;
* Update: Atualiza a lógica do jogo;
* Draw: Renderiza os elementos do jogo no ecrã.


**Classe "Globals.cs":** Esta classes contém variáveis globais e métodos usados ao longo do jogo. Contém as seguintes propriedades:
* TotalSeconds: Recebe ou define o tempo total decorrido;
* Content: Recebe ou define o gestor de conteúdo para carregar as propriedades do jogo.
* SpriteBatch: Recebe ou define o conjunto de sprites para desenhar os sprites no jogo.
* Bounds: Recebe ou define os limites do mundo do jogo. 


**Classe "Program.cs":** Contém o ponto de entrada para o jogo. Apenas contém o método "Main" que é o ponto de entrada do Monogame. M





**Pasta "Manager", a qual contém:**
* **Classe ""GameManager.cs""**: Gerencia a lógica do jogo. Contém as propriedades e métodos:
Propriedades: 
  * _player: Representa o personagem "player".
  * _monsters: Representa os monstros no jogo.
Métodos:
  * Update: Atualiza o lógica do jogo.
  * Draw: Renderiza os elementos do jogo no ecrã.


* **Classe ""InputManager.cs""**: Gerencia o input do jogador no jogo. Contém as propriedades e métodos:
Propriedades: 
  * * Direction: Recebe a direção do movimento baseado no input do utilizador.
  * * MousePosition: Recebe a posição atual do rato.
  * * MouseClicked, MouseRightClicked, MouseLeftDown, SpacePressed: Indica o input do rato e teclado.
Método:
  * * Update: Atualiza o estado do input.


* **Classe ""MonsterManager.cs""**: Gerencia os monstros no jogo. Contém os métodos:
* * Init: Inicializa o gerenciador dos monstros. 
* * Reset: Reseta o estado do gerenciador.
* * RandomPosition: Gera uma posição aleatóra para um monstro.
* * AddMonster: Adiciona um novo monstro ao jogo.
* * Update: Atualiza a posição dos monstros e verifica se há colisões.
* * Draw: Renderiza os monstros no ecrã.


* **Classe ""ProjectileManager.cs""**: Gerencia os monstros no jogo. Contém as propriedades e métodos:
Propriedade:
* * List Projectiles: Lista de projeteis ativos.
Métodos:
* * Init: Inicializa o gerente com a textura do projetil.
* * Reset: Reseta a list de projeteis.
* * AddProjectile: Adiciona um novo projetil à lista.
* * Update: Atualiza os projeteis e lida com as colisões.
* * Draw: Renderiza todos os projeteis.

  
* **Classe ""UIManager.cs""**: Gerencia elementos da User Interface no jogo. Contém os métodos:
* * Init: Inicializa o gerenciador da UI.
* * Draw: Desenha os elementos gerais da User Interface.
* * DrawPlayerInfo: Renderiza elementos da UI relacionados ao player.


* **Classe ""XPManager.cs""**: Gerencia os pontos de experiência no jogo. Contém os métodos:
* * Init: Inicializa o gerenciador do XP.
* * Reset: Reseta o estado do gerenciador. 
* * AddXP: Adiciona novo XP numa posição específica.
* * Update: Atualiza as posições e tempo de vida do XP.
* * Draw: Renderiza o XP na tela. 







**Pasta "Stuff", a qual contém:**
* **Classe ""Background.cs""**: Representa o plano de fundo do jogo. Contém o método "Draw" que renderiza o plano de fundo na tela.


* **Classe "Monsters.cs"**: Representa um monstro no jogo. Contém as propriedades e métodos:
Propriedades:
* * HP: Recebe ou define os "Pontos de Saúde" do monstro.
* * Speed: Recebe ou define a velocidade do monstro.
Métodos:
* * TakeDamage: Reduz a saúde do monstro quando este leva dano. 
* * Update: Atualiza a posição e rotação do monstro baseado na posição do jogador. 


* **Classe "Player.cs"**: Representa o personagem do Player no jogo. Contém as propriedades e métodos:
Propriedades:
* * Dead: Indica se o jogador está morto.
* * XP: Recebe ou define os "Pontos de Experiência" do jogador.
Métodos:
* * GetXP: Adiciona os pontos de experiência ao jogador. 
* * Reset: Reseta o estado do jogador.
* * SwapWeapon: Troca as armas.
* * Update: Atualiza o posição, rotação e ações do player baseado em input do utilizador e nas interações com monstros.


* **Classe "XP.cs"**: Represnta os pontos de experiência no jogo. Contém as propriedades e métodos:
Propriedades:
* * Lifespan: Recebe ou define a vida restante do XP.
Métodos: 
* * Update: Atualiza as propiedades dos "Pontos de Experiência".
* * Collect: Coleta os "Pontos de Experiência".


* **Pasta "Attack", a qual contém:**
* * **Classe ""Projectile.cs""**: Representa o projetile disparado pela arma do player. Contém os métodos:
* * * Update: Atualiza a posição e tempo de vida dos projeteis. 
* * * IsOutOfBounds: Verifica se o projétil está fora dos limites do jogo.
* * * CheckCollision: Verifica a colisão com monstros. 
* * * Draw: Renderiza os projeteis no ecrã.


* * **Classe ""ProjectileData.cs""**: Contém dados para a crição de projeteis.


* * **Classe ""Weapon.cs""**: Representa a arma do player no jogo. Contém os métodos:
* * * Reload: Recarrega a arma.
* * * CreateProjectiles: Cria projéteis quando a arma é disparada. 
* * * Fire: Dispara a arma.
* * * Update: Atualiza o tempo de espera da arma e o estado de recarregar a arma.


* **Pasta "Base", a qual contém:**
* * **Classe ""MovingSprite.cs""**: Representa um sprite com capacidade de movimento. Contém a propriedade "Speed" que recebe ou define e velocidade do sprite.


* * **Classe ""Sprite.cs""**: Representa um sprite estático. Contém as propriedades e métodos:
Propriedades: 
* * * Position: Recebe ou define a posição do sprite.
* * * Rotation: Recebe ou define a rotação do sprite.
* * * Scale: Recebe ou define a escala do sprite.
* * * Color: Recebe ou define a cor do sprite.
Métodos:
* * * Draw: Renderiza o sprite no ecrã.



