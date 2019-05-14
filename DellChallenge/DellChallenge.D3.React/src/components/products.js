import React, { Component } from "react";
import Validation from "../validation";

class ProductList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }

  deleteProd = (it) => {
    fetch("http://localhost:5000/api/products/"+it.id,{method:"DELETE"})
      .then(res => res.json())
      .then(
        result => {
          var array = [...this.state.items]; // make a separate copy of the array
          var index = array.indexOf(it)
          if (index !== -1) {
            array.splice(index, 1);
            this.setState({items: array});
          }
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            error
          });
        }
      );
  }

  componentDidMount() {
    fetch("http://localhost:5000/api/products")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      );
  }

  render() {
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
          <ul>
            {items.map(item => (
              <li key={item.id}>
                {item.name} - {item.category}
                <button onClick={()=>this.deleteProd(item)}>Delete</button>
                <a className="btn btn-primary" href={"/updproduct/"+item.id}>Update </a>
              </li>
            ))}
          </ul>
      );
    }
  }
}

class Products extends Component {
  render() {
    return (
      <React.Fragment>
        <h1 className="display-4">Products</h1>
        <ProductList />
        <Validation />
      </React.Fragment>
    );
  }
}
export default Products;
