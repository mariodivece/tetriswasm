namespace TetrisWasm.Client.Shared
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using System.Threading.Tasks;
    using TetrisWasm.Shared;

    public partial class TetrisBoardKeyboard
    {
        private DotNetObjectReference<TetrisBoardKeyboard> ComponentReference;

        [CascadingParameter(Name = nameof(Board))]
        public TetrisBoard Board { get; set; }

        [Parameter]
        public EventCallback OnInputCallback { get; set; }

        [Inject]
        private IJSRuntime JS { get; set; }

        [JSInvokable]
        public async Task MoveLeft()
        {
            Board.MoveLeft();
            await OnInputCallback.InvokeAsync(this);
        }

        [JSInvokable]
        public async Task MoveRight()
        {
            Board.MoveRight();
            await OnInputCallback.InvokeAsync(this);
        }

        [JSInvokable]
        public async Task MoveDown()
        {
            Board.MoveDown();
            await OnInputCallback.InvokeAsync(this);
        }

        [JSInvokable]
        public async Task Rotate()
        {
            Board.Rotate();
            await OnInputCallback.InvokeAsync(this);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                ComponentReference = DotNetObjectReference.Create(this);
                await JS.InvokeVoidAsync("BoardController.bindKeyboard", ComponentReference);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
