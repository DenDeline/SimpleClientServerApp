import React from 'react';
import {API_URL, GET_USERS} from '../constants'

class DisplayInfo extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items:[]
        };
    }

    async componentDidMount() {
        await fetch("https://localhost:5001/api/users", {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Host': 'https://localhost:3000',
                'Origin': 'https://localhost:3000'
            }
        })
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: result
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error: error
                    });
                    console.log('Response', error);
                }
            )
    }

    render(){
        const {error, isLoaded, items} = this.state;
        if(error) {
            return <div>Ошибка: {error.message}</div>
        }
        else if(!isLoaded) {
            return <div>Загрузка...</div>
        }
        else{
            return (
                <ul>
                    {items.map(item => (
                        <li key={item.id}>
                            {item.name} {item.surname}
                        </li>
                    ))}
                </ul>
            )
        }
    }
}

export default DisplayInfo;