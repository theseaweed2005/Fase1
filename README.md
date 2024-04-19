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


* W - andar para a frente
* A - andar para a esquerda
* S - andar para trás
* D - andar para a direita
* LeftShift - acelerar



**Controlos de Mira**

* T - apontar para cima
* F - apontar para a esquerda
* G - apontar para baixo
* J - apontar para a direita
* Space - disparar




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

**Pasta "Effects":** Contém um conjunto de arquivos que criam, atualizam e renderizam os efeitos visuais e sonoros do jogo, como a poeira, a chuva e os respetivos efeitos sonoros.
* ClsDust.cs: Gera partículas de poeira aleatórias ao redor das rodas do tanque, podendo variar com o tempo e gravidade e, são removidas se entrarem em contato com o terreno ou alcançarem uma certa altura.
* ClsParticleDust: Gera a posição e a velocidade de cada única partícula de poeira.
* ClsParticleRain: Gera partículas de chuva aleatórias no mapa, que são removidas se atingirem o chão ou saírem dos limites da área.
* ClsRain: Gera o sistema das partículas de chuva.
* ClsSoundEffect: Inicializa e reproduz os efeitos sonoros, tendo a opção de definir se deve ser reproduzido em loop ou não.
```c#
using Microsoft.Xna.Framework.Audio;

namespace TrabalhoPratico_Monogame_2ano.Effects
{
    internal class ClsSoundEffect
    {
        private SoundEffectInstance _soundEffectInstance;
        private bool _loop;

        public ClsSoundEffect(SoundEffect sound, float volume)
        {
            _soundEffectInstance = sound.CreateInstance();
            _soundEffectInstance.Volume = volume;
            _loop = true;
        }

        public void Play()
        {
            if (_loop)
            {
                _soundEffectInstance.Play();
                _loop = false;
            }
        }

        public void PlayWithLoop()
        {
            _soundEffectInstance.Play();
        }
    }
}
```


**Pasta "Managers":** Contém o arquivo que resposável for gerir os comandos do teclado no monogame.
* ClsKeyboardManager: Este arquivo oferece métodos para ajustar o ângulo de rotação do canhão, movimentar os objetos numa cena e limitar o ângulo dentro de valores específicos, tornando possível a interação com o ambiente através do teclado.


**Arquivo "Game1.cs":** Este arquivo inicializa a camera e inicializa e carrega os recursos (textura, modelos 3D e efeitos sonoros). No método Update, são atualizados a camera, os tanques, os efeitos da chuva e a interação com o teclado e, também verifica se o jogador pressionou o botão "Back" do controle ou a tecla "Escape" para sair do jogo. No método Draw, os elementos do jogo, como o terreno, os tanques, as balas e o efeitos da chuva, são renderizados e a camera é usada para determinar o ponto de vista da cena.

```c#
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TrabalhoPratico_Monogame_2ano.Components;
using TrabalhoPratico_Monogame_2ano.Effects;

namespace TrabalhoPratico_Monogame_2ano
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private ClsTerrain _terrain;
        private ClsTank _tank, _tankEnemy;
        private ClsRain _effectRain;
        private ClsSoundEffect _soundRain;
        private ClsObject _pokeball;
        private List<ClsObject> _pokeballList;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            _pokeballList = new List<ClsObject>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Mouse.SetPosition(_graphics.GraphicsDevice.Viewport.Width / 2, _graphics.GraphicsDevice.Viewport.Height / 2);
            _terrain = new ClsTerrain(_graphics.GraphicsDevice, Content.Load<Texture2D>("lh3d1"), Content.Load<Texture2D>("sand"));
            _tank = new ClsTank(_graphics.GraphicsDevice, this, Content.Load<Model>("tank"), new Vector3(50f, 0f, 40f), false, new Keys[] { Keys.A, Keys.W, Keys.D, Keys.S, Keys.Q, Keys.E, Keys.F, Keys.H, Keys.T, Keys.G, Keys.LeftShift, Keys.Space });
            _tankEnemy = new ClsTank(_graphics.GraphicsDevice, this, Content.Load<Model>("tank"), new Vector3(64f, 0f, 64f), true, new Keys[] { Keys.J, Keys.I, Keys.L, Keys.K, Keys.N, Keys.M, Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.RightShift, Keys.Enter });
            _effectRain = new ClsRain(GraphicsDevice);
            _soundRain = new ClsSoundEffect(Content.Load<SoundEffect>("SoundEffect/rain"), 0.03f);

            for (int i = 0; i < 20; i++)
            {
                _pokeball = new ClsObject(Content.Load<Model>("pokeball"), _terrain);
                _pokeballList.Add(_pokeball);
            }

            ClsCamera.CreateCamera(_graphics.GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ClsCamera.UpdateCamera(gameTime, _graphics.GraphicsDevice, _tank, _terrain);
            _tank.Update(gameTime, _terrain, _tankEnemy);
            _tankEnemy.Update(gameTime, _terrain, _tank);
            _effectRain.Update(gameTime, _terrain);
            _soundRain.PlayWithLoop();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            _effectRain.Draw(ClsCamera.Instance.View, ClsCamera.Instance.Projection);
            _terrain.Draw(_graphics.GraphicsDevice, ClsCamera.Instance.View, ClsCamera.Instance.Projection);
            _tank.Draw(_graphics.GraphicsDevice, ClsCamera.Instance.View, ClsCamera.Instance.Projection, Vector3.Zero);
            _tankEnemy.Draw(_graphics.GraphicsDevice, ClsCamera.Instance.View, ClsCamera.Instance.Projection, Vector3.UnitX);
            foreach (ClsObject pokeball in _pokeballList)
                pokeball.Draw();

            base.Draw(gameTime);
        }
    }
}

```

**Arquivo "Program.cs":** Este arquivo é o ponto de entrada principal da aplicação MonoGame e ele define o namespace onde a classe Program está localizada, declara uma classe estática chamada Program, que serve como ponto de entrada da aplicação e inicia o ciclo de execução do jogo e controla o loop de atualização e renderização do mesmo.

```c#
using System;

namespace TrabalhoPratico_Monogame_2ano
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
```

# Créditos

**Jogo:** https://github.com/RuiCardoso021/TrabalhoPratico_Monogame_2ano.git
