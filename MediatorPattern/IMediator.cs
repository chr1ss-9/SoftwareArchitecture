namespace MediatorPattern {
    public interface IMediator {
        // Allows publishing an event to its subscribers.
        void Publish(string eventName, object eventArgs);
        // Allows subscribing to an event by providing an event name and a callback action.
        void Subscribe(string eventName, Action<object> callback);
    }
}