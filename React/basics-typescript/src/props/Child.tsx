interface ChildProps {
  color: string;
  onClickButton: () => void;
}

export const Child = ({ color, onClickButton }: ChildProps) => {
  return (
    <div>
      {color}
      <button onClick={onClickButton}>Click me</button>
    </div>
  );
};

export const ChildAsFC: React.FC<ChildProps> = ({
  color,
  onClickButton,
  children,
}) => {
  return (
    <div>
      {color}
      {children}
      <button onClick={onClickButton}>Click me</button>
    </div>
  );
};
