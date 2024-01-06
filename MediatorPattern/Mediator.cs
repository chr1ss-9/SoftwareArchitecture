namespace MediatorPattern {
    public class Mediator : IMediator {
        // Contains a dictionary of event names and a list of callbacks for each event name.
        private readonly Dictionary<string, List<Action<object>>> _eventCallbacks = new();  
        
        public void Publish(string eventName, object eventArgs) {
            // Check if any callbacks are registered for the given event name.
            if (_eventCallbacks.ContainsKey(eventName)) {
                // Iterate through all registered callbacks and invoke them.
                foreach (var callback in _eventCallbacks[eventName]) {
                    callback(eventArgs);
                }
            }
        }

        public void Subscribe(string eventName, Action<object> callback) {
            // Check if this event name is not already in the dictionary, create a new list of callbacks.
            if (!_eventCallbacks.ContainsKey(eventName)) {
                _eventCallbacks[eventName] = new List<Action<object>>();
            }
            // Add the provided callback to the list of callbacks.
            _eventCallbacks[eventName].Add(callback);
        }
    }
}
