# EventEmitter

```
EventEmitter<string,object> emitter = new EventEmiiter<string,object>();

emitter.on("event",(param)=>{
//Event Callback
});

//Remove event listener
emitter.off("event",callback);

//Listen to this event for once only
//emiiter.once("event",callback);
```
