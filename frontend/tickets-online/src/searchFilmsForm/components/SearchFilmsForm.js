import React from 'react'

class SearchFilmsForm extends React.Component{
  constructor(props){
    super(props);
  }

  render(){
    return(
      <form className="form-inline">
        <input onInput={this.props.onInputChange} className="form-control mr-sm-2" type="search" placeholder="Search Film" aria-label="Search"/>
      <button onClick={this.props.onSearchClick} type="button" className="btn btn-outline-success my-2 my-sm-0">Search</button>
      </form>
    )
  }
}

export {SearchFilmsForm}
