import { useState } from "react";
import { useActions } from "../hooks/useActions";
import { useTypedSelector } from "../hooks/useTypedSelector";

const RepositoriesList: React.FC = () => {
  const [term, setTerm] = useState("");
  const { searchRepositories } = useActions();
  const { loading, error, data } = useTypedSelector(
    (state) => state.repositories
  );

  const onSubmit = (event: React.MouseEvent<HTMLFormElement, MouseEvent>) => {
    event.preventDefault();
    searchRepositories(term);
  };

  const onChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setTerm(event.target.value);
  };

  return (
    <form onSubmit={onSubmit}>
      <input type="text" onChange={onChange} />
      <button>Search</button>
      {loading && <div>Loading...</div>}
      {error && <div>{error}</div>}
      <hr />
      {!loading && !error && data && (
        <ul>
          {data.map((value) => (
            <li key={value}>{value}</li>
          ))}
        </ul>
      )}
    </form>
  );
};

export default RepositoriesList;
