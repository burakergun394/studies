import { Component, ReactNode } from "react";

interface User {
  name: string;
  age: number;
}

interface UserSearchProps {
  users: User[];
}

interface UserSearchState {
  name: string;
  user: User | undefined;
}

class UserSearch extends Component<UserSearchProps, UserSearchState> {
  state: UserSearchState = {
    name: "",
    user: undefined,
  };
  onClick = () => {
    const foundUser = this.props.users.find((user) => {
      return user.name === this.state.name;
    });
    this.setState({
      user: foundUser,
    });
  };
  render(): ReactNode {
    return (
      <div>
        User Search
        <input
          type="text"
          value={this.state.name}
          onChange={(e) =>
            this.setState({
              name: e.target.value,
            })
          }
        />
        <button onClick={this.onClick}>Find User</button>
        <div>
          {this.state.user && <h6>{this.state.user.name}</h6>}
          {this.state.user && <h6>{this.state.user.age}</h6>}
        </div>
      </div>
    );
  }
}

export default UserSearch;
