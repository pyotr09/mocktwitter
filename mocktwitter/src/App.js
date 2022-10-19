import React, { Component } from 'react';
import Timeline from "./Timeline";
import UserList from "./UserList";

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { tweets: [], usersOpen: false, newTweetText: '', users: [] };
        this.submitTweet = this.submitTweet.bind(this);
        this.fetchTimelineTweets = this.fetchTimelineTweets.bind(this);
        this.updateFollows = this.updateFollows.bind(this);
    }

    componentDidMount() {
        this.fetchTimelineTweets();
        this.fetchUsers();
    }

    render() {
        let contents = this.state.usersOpen
            ? <UserList users ={this.state.users} updateFollows={this.updateFollows} />
            : <Timeline tweets={this.state.tweets} />;

        return (
            <div>
                <h1 id="tabelLabel">Mock Twitter</h1>

                <form onSubmit={this.submitTweet}>
                    <label>Create new tweet:</label><br />
                    <input type="text" value={this.state.newTweetText} onChange={(e) => this.setState({newTweetText: e.target.value})} /><br />
                    <input type="submit" value="Submit"  />
                </form>

                <button onClick={this.toggleUsersOpen}>{!this.state.usersOpen ? "Find Users" : "Return to Timeline"}</button>
                <button onClick={this.fetchTimelineTweets}>{"Refresh Timeline"}</button>
                {contents}
            </div>
        );
    }
    
    async updateFollows(userIds) {
        await fetch('https://localhost:7086/userfollow',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body:
                    JSON.stringify({
                        "ActiveUserId": 1,
                        "FollowedUserIds": userIds,
                    })
            }
        );
        await this.fetchUsers();
        await this.fetchTimelineTweets();
    }

    toggleUsersOpen = () => {
        let usersOpen = this.state.usersOpen;
        this.setState({ usersOpen: !usersOpen }) 
    }

    async fetchTimelineTweets() {
        const response = await fetch('https://localhost:7086/timeline/1');
        const data = await response.json();
        this.setState({ tweets: data});
    }

    async fetchUsers() {
        const response = await fetch('https://localhost:7086/users');
        const data = await response.json();
        this.setState({ users: data });
    }
    
    async submitTweet(e) {
        e.preventDefault();
        await fetch('https://localhost:7086/mocktweets',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: 
                    JSON.stringify({
                        "timeStamp": new Date().toISOString(),
                        "tweet": this.state.newTweetText,
                        "userId": 1
                    })
            }
            );
        this.setState({newTweetText: ''});
        await this.fetchTimelineTweets();
    }
    
}
