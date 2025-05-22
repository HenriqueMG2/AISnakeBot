# SnakeBot Framework 🐍 (Unity)

Este framework foi desenvolvido para suportar o estudo e criação de agentes inteligentes inspirados no comportamento das cobrinhas do jogo **Slither.io**. Ele é voltado para a disciplina de Inteligência Artificial para Jogos, permitindo que estudantes explorem conceitos de agentes reativos, movimentação e tomada de decisão.

Desenvolvido com base no repositório original:  
🔗 [https://github.com/fellowsheep/IA2022-2](https://github.com/fellowsheep/IA2022-2)

---

## 📁 Estrutura dos Scripts

### 📄 GameLogic.cs

Responsável por:

- Instanciar cobras (`snakes`) e orbes no cenário.
- Alternar entre agentes com as teclas `Q` e `E`.
- Controlar a lógica geral de spawn e remoção de objetos.

### 📄 SnakeMovement.cs

Controla a movimentação do agente (cobra).

- Executa o comportamento de IA atribuído.
- Permite dash (velocidade extra com sacrifício de segmento).
- Gerencia colisões com orbes e outros corpos.
- Controla a câmera quando o agente está selecionado.

### 📄 SnakeBody.cs

Responsável por posicionar e animar as partes do corpo da cobra.

- Usa `SmoothDamp` para seguir o segmento anterior.
- Define cor alternada para os segmentos.

### 📄 OrbBehavior.cs

Orbe que é consumido pelas cobras.

- Desaparece automaticamente após 30 segundos.

### 📄 NameBanner.cs

Exibe o nome da cobra acima do agente com `TextMeshPro`.

- Mantém orientação fixa (sem rotação).

### 📄 AIBehaviour.cs (ScriptableObject)

**Classe base** para implementar diferentes comportamentos de IA.

- Métodos principais: `Init()` e `Execute()`.
- Atributos:
  - `owner`: referência para a cobra (GameObject).
  - `direction`: direção atual do movimento da cobra.
  - `randomPoint`: ponto aleatório para wander.
  - `target`: referência opcional a outro objeto de interesse.

---

## 🤖 Bots Implementados

### Dummy.cs

- Movimento aleatório com troca periódica de direção.
- Utiliza `MoveForward()` com `Vector2.MoveTowards`.

### Playerbot.cs

- Controlado pelo mouse (para testes).
- Rotaciona e se movimenta em direção ao cursor.

### SmartBot.cs ✅

- Agente que **prioriza objetivos** com base em regras simples:
  1. **Seek Orb** (busca o orbe mais próximo).
  2. **Flee** (foge de inimigos próximos).
  3. **Wander** (anda aleatoriamente se não houver estímulo).
- Usa `perceptionRadius` e `dangerRadius` para definir zonas de interesse e risco.
- Desenha círculos de percepção e perigo com `Debug.DrawLine` nos `Gizmos`.
- Implementa uma IA baseada em **prioridades dinâmicas**.

---

## 🚀 Como Criar um Novo Bot

1. Crie um novo script `C#` derivado de `AIBehaviour`.
2. Implemente os métodos `Init()` e `Execute()`.
3. Registre como um `ScriptableObject` com `[CreateAssetMenu]`.
4. Associe no editor Unity à cobra desejada via `SnakeMovement.SetBehaviour()`.

---

## 🐍 Como Instanciar Cobras no Código

No script `GameLogic.cs`, a criação de novas cobrinhas é feita com `Instantiate`:

```csharp
GameObject newSnake = Instantiate(snakePrefab, new Vector3(5, 5, 0), Quaternion.identity);
newSnake.name = "SnakeBot01";
snakes.Add(newSnake);

// 0 = Dummy, 1 = Player, 2 = SmartBot
newSnake.GetComponentInChildren<SnakeMovement>().SetBehaviour(behaviors[2]);
Ou, para um bot controlado pelo mouse:

```csharp
GameObject playerSnake = Instantiate(snakePrefab, new Vector3(-5, -5, 0), Quaternion.identity);
playerSnake.name = "Jogador";
snakes.Add(playerSnake);

// Comportamento controlado pelo jogador (índice 1, por exemplo)
playerSnake.GetComponentInChildren<SnakeMovement>().SetBehaviour(behaviors[1]);

// Define a cobra que inicia no foco da câmera
playerSnake.GetComponentInChildren<SnakeMovement>().selected = true;
```

---

## 📦 Repositório Original

[https://github.com/fellowsheep/IA2022-2](https://github.com/fellowsheep/IA2022-2)

---

## 📚 Referências

- Millington, I. (2019). *AI for Games* (3rd ed.). CRC Press.
- Slither.io[: ](https://slither.io)[https://slither.io](https://slither.io)

---

**Desenvolvido para fins didáticos.** 🎓

```
