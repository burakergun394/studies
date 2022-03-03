import { ChildAsFC } from "./Child";

const Parent = () => {
  return (
    <ChildAsFC color="red" onClickButton={() => console.log("On Click Button")}>
      asaa
    </ChildAsFC>
  );
};

export default Parent;
