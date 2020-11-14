import { notification } from 'antd';
import { API_URL } from '../util/constants'

let getHeaders = () => {
    let obj = {
      method: 'get',
      headers: new Headers({
        'Content-Type': 'application/json'
      })
    };
  
    return obj;
  }

  let postHeaders = (data) => {
    let obj = {
      method: 'post',
      headers: new Headers({
        'Content-Type': 'application/json'
      }),
      body: JSON.stringify(data)
    };
  
    return obj;
  }

  export async function get(url) {
    let obj = getHeaders();
  
    let response = await fetch(`${API_URL}${url}`, obj);
  
    let result = await response.json();
  
    if (result.status) {
      return result.data;
    }
  
    notification.error({
      message: `Error`,
      description: `${result.message} `,
    });
   
  
  }
  
  export async function post(url, data) {
    
    let obj = postHeaders(data);
  
    let response = await fetch(`${API_URL}${url}`, obj);

  
    let result = await response.json();
  
    if (result.status) {
      return result;
    }
  
    notification.error({
      message: `Error`,
      description: `${result.message} `,
    });
   
    return result;
  
  }

  export let request = {
    get,
    post,
  }
  