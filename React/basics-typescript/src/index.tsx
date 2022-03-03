import React from "react";
import ReactDOM from "react-dom";
import Parent from "./props/Parent";
import GuestList from "./state/GuestList";
import EventComponent from "./events/EventComponent";
import UserSearch from "./refs/UserSearch";

const App = () => {
  const users = [
    { name: "Sarah", age: 20 },
    { name: "Alex", age: 20 },
    { name: "Michael", age: 20 },
  ];
  return (
    <div>
      {/* <Parent></Parent> */}
      {/* <GuestList></GuestList> */}
      <UserSearch></UserSearch>
      {/* <EventComponent></EventComponent> */}
    </div>
  );
};

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.querySelector("#root")
);
