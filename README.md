# 🐍 Snake AI - Unity 2D Project

Este projeto é uma simulação de cobrinhas autônomas controladas por Inteligência Artificial no estilo *Slither.io*, desenvolvido em Unity 2D. O foco está na implementação de **Steering Behaviors** para criar agentes que buscam orbes, evitam cobras maiores e se movimentam de forma fluida no ambiente.

---

## 🎮 Demonstração

> Agentes autônomos navegam por um ambiente bidimensional, tomando decisões baseadas em percepção, tamanho e distância.

![Gameplay GIF](link-para-o-gif-ou-imagem-aqui)

---

## 🧠 Funcionalidades de IA

As cobrinhas usam uma combinação de **comportamentos de steering** para decidir como se mover no ambiente:

- **Seek** – persegue o orbe mais próximo.
- **Flee** – foge de cobrinhas maiores próximas.
- **Wander** – movimento aleatório quando sem ameaças ou alvos.
- **Priority Steering** – prioriza fugir > caçar > buscar orbes > andar aleatoriamente.

---

## 📁 Estrutura do Projeto

Assets/
│
├── Scripts/
│ ├── SnakeMovement.cs # Comportamento base de movimento
│ ├── AIBehaviour.cs # Classe base para comportamentos
│ ├── PlayerbotAuto.cs # Comportamento autônomo do bot
│
├── Prefabs/
│ ├── SnakePrefab
│ └── Orb
│
├── Scenes/
│ └── MainScene.unity

## 🛠️ Tecnologias

- **Unity 2021+**
- **C#**
- **IA baseada em Steering Behaviors**
- Física 2D integrada com movimentação direta via posição (sem Rigidbodies)

---

## 📚 Referências Teóricas

- *Artificial Intelligence for Games* – Ian Millington & John Funge
- *Programming Game AI by Example* – Mat Buckland
- *Steering Behaviors for Autonomous Characters* – Craig Reynolds (1999)
- *Game AI Pro* – Steve Rabin (série)

---

## 🚀 Como Rodar

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/snake-ai-unity.git
