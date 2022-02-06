import React from 'react';
import { render } from 'react-dom';
import {
  ApolloClient,
  InMemoryCache,
  ApolloProvider,
  useQuery,
  gql
} from "@apollo/client";

const client = new ApolloClient({
  uri: '/graphql/',
  cache: new InMemoryCache(),
  fetchOptions: {
      mode: 'no-cors',
    },
});


const GET_CUSTOMER = gql`
  query GetCustomer{
      customer{
        firstName,
        lastName
      }
    }
`;


function LoadCustomer() {
  const { loading, error, data } = useQuery(GET_CUSTOMER);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :(</p>;

  return(
    <div>
      {data.customer.firstName}
      {data.customer.lastName}
    </div>
  );
  // return data.customer(({ firstName, lastName }) => (
  //   <div key={firstName}>
  //     <p>
  //       {firstName}: {lastName}
  //     </p>
  //   </div>
  // ));
}

// // ReactDOM.render(
// //   <React.StrictMode>
// //     <App />
// //   </React.StrictMode>,
// //   document.getElementById('root')
// // );
// var greeting = createElement('h1', { className: 'greeting' }, 'Hello, world!');
// ReactDOM.render(greeting, document.getElementById('root'));
function App() {
  return (
    <div>
      <h2>My first Apollo app 🚀</h2>
      <LoadCustomer/>
    </div>
  );
}


render(
  <ApolloProvider client={client}>
    <App />
  </ApolloProvider>,
  document.getElementById('root'),
);


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
//reportWebVitals();


client
  .query({
    query: gql`
      query {
        customer{
          firstName,
          lastName
        }
      }
    `
  })
  .then(result => console.log(result));

