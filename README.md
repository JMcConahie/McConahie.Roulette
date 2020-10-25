# McConahie.Roulette
Roulette Library

### Example

Sample class implementing a game of Classic Roulette

```csharp
    public class ClassicGame
    {
        public async Task PlayAsync(CancellationToken cancellationToken)
        {
            var player1 = new Player()
            {
                Name = "Jesse McConahie",
                Purse = 300
            };

            var player2 = new Player()
            {
                Name = "John Smith",
                Purse = 500
            };

            var players = new List<Player>() { player1, player2 };

            var inputManager = new TextInputManager();
            var outputManager = new TextOutputManager();

            var roulette = new ClassicRoulette(players, inputManager, outputManager, cancellationToken);
            await roulette.PlayGameAsync();
        }
    }
```
