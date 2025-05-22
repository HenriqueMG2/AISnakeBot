# 🐍 Snake AI - Unity 2D Project

Este projeto é uma simulação de cobrinhas autônomas controladas por Inteligência Artificial no estilo *Slither.io*, desenvolvido em Unity 2D. O foco está na implementação de **Steering Behaviors** para criar agentes que buscam orbes, evitam cobras maiores e se movimentam de forma fluida no ambiente.

---

## 🧠 Funcionalidades de IA

As cobrinhas usam uma combinação de **comportamentos de steering** para decidir como se mover no ambiente:

- **Seek** – persegue o orbe mais próximo.
- **Flee** – foge de cobrinhas maiores próximas.
- **Wander** – movimento aleatório quando sem ameaças ou alvos.
- **Priority Steering** – prioriza fugir > caçar > buscar orbes > andar aleatoriamente.

---

## 🛠️ Tecnologias

- **Unity 2021+**
- **C#**
- **IA baseada em Steering Behaviors**
- Física 2D integrada com movimentação direta via posição (sem Rigidbodies)

---

## 📚 Referências Teóricas

- Millington, I. (2019). *AI for Games* (3rd ed.). CRC Press.
- Buckland, M. *Programming Game AI by Example*.
- Reynolds, C. (1999). *Steering Behaviors for Autonomous Characters*.
- Rabin, S. *Game AI Pro* (série).

---

## 🔗 Referências Adicionais

- Jogo de referência: [Slither.io](https://slither.io)
- Repositório base utilizado: [fellowssheep/IA2022-2](https://github.com/fellowsheep/IA2022-2)

---

## 🚀 Como Rodar

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/snake-ai-unity.git
   
2. Abra o projeto no Unity:
   - Use o Unity Hub.
   - Clique em "Add" e selecione a pasta do projeto clonado.
   - Certifique-se de estar usando a versão Unity 2021.3 ou superior.
     
3. Abra a cena principal:
   - Vá até a pasta Assets/Scenes/.
   - Dê dois cliques em MainScene.unity para abri-la.

4. Rode o projeto:
   - Pressione Play dentro do editor Unity para iniciar a simulação.

📚 Referências
Millington, I. (2019). AI for Games (3rd ed.). CRC Press.

Jogo de referência: Slither.io

Repositório base utilizado: https://github.com/fellowsheep/IA2022-2

Outros materiais consultados:

Artificial Intelligence for Games – Ian Millington & John Funge

Programming Game AI by Example – Mat Buckland

Steering Behaviors for Autonomous Characters – Craig Reynolds (1999)

Game AI Pro – Steve Rabin (série)
