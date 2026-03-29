using System;
using System.Windows.Forms;
using SpaceBot.Core.Services;

namespace SpaceBot.App
{
    public sealed class MainForm : Form
    {
        private readonly BotOrchestrator _orchestrator = new BotOrchestrator(new NearestTargetSelector());
        private readonly Button _startButton = new Button { Text = "Start", Dock = DockStyle.Top };
        private readonly Label _stateLabel = new Label { Text = "State: Idle", Dock = DockStyle.Top, Height = 30 };
        private readonly Timer _timer = new Timer { Interval = 150 };

        public MainForm()
        {
            Text = "SpaceBot MVP";
            Width = 420;
            Height = 220;

            _startButton.Click += OnStartClick;
            _timer.Tick += OnTick;

            Controls.Add(_stateLabel);
            Controls.Add(_startButton);
        }

        private void OnStartClick(object sender, EventArgs e)
        {
            _timer.Enabled = !_timer.Enabled;
            _startButton.Text = _timer.Enabled ? "Stop" : "Start";
        }

        private void OnTick(object sender, EventArgs e)
        {
            // В MVP здесь будут вызовы Vision/Input. Пока только шаг FSM.
            _orchestrator.Tick(ship: null, boxes: null, targetCollected: false);
            _stateLabel.Text = "State: " + _orchestrator.Context.State;
        }
    }
}
