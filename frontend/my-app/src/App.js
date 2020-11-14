import { Card, notification } from 'antd'
import LikeButton from './components/LikeButton'
import { articleService } from "./services/article";
import { useState, useEffect } from "react";

import './App.css'
function App() {

  const [state, setstate] = useState({ articles: [] })

  useEffect(() => {

    getArticles();

  }, [])


  const getArticles = async () => {
    let result = await articleService.getArticles();
    setstate({ ...state, articles: result })
  }

  const likeArticle = async (id) => {
    let result = await articleService.likePost(id);
    let oldState = state.articles;

    let newList = oldState.map((data,index) => {
      if(data.id === result.data.id){
        data.likes = result.data.likes;
        return data;
      }
      return data;
    });

    setstate({ ...state, articles: newList })

    if(result.status === true){
      notification.success({
        message: `Suceess`,
        description: `${result.message} `,
      });
    }
  }


  return (
    <div className="container">
      
      <h1 style={{textAlign:"center"}}>Rock Content Coding Challenge</h1>
      <br />
      <div className="card_parent">

        {state.articles?.map((data, index) => {
          return (
            <div className="cards">
              <Card key={data.id} className="" title={data.title} bordered={true} style={{ width: 300 }}>
                {data.body}
                
                <br/>
                
                <br/>
                <LikeButton likeArticle={() => likeArticle(data.id)} likes={data.likes} />
              </Card>
            </div>

          )
        })

        }
      </div>
    </div>
  );
}

export default App;
