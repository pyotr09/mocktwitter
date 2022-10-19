import React from 'react';

export default function Timeline(props) {
    return (
        <div>

            <table>
                <thead>
                <tr>
                    <th>User</th>
                    <th>Tweet</th>
                    <th>Time</th>
                </tr>
                </thead>
                <tbody>
                {props.tweets.map(tweet =>
                    <tr key={tweet.timeStamp}>
                        <td>{tweet.user}</td>
                        <td>{tweet.tweet}</td>
                        <td>{tweet.timeStamp}</td>
                    </tr>
                )}
                </tbody>
            </table>
        </div>
        );
}