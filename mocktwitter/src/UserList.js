import React, {useState} from 'react';

export default function UserList(props) {
    const [followedUserIds, setFollowedUserIds] = useState(props.users.find(u => u.id === 1).followingUsers.map((u) => u.id));
    
    const checkedChanged = (e, user) => {        
        if (e.target.checked) {
            console.log('adding')
            console.log(followedUserIds);
            setFollowedUserIds(followedUserIds.concat([user.id]));
        }
        else {
            console.log('removing')
            console.log(followedUserIds);
            setFollowedUserIds(followedUserIds.filter(u => u !== user.id));
        }
    }
    
    return (
        <div>
        <table>
            <thead>
            <tr>
                <th>User</th>
                <th>Follow?</th>
            </tr>
            </thead>
            <tbody>
            {props.users.filter(u => u.id !== 1).map(user =>
                <tr key={user.userName}>
                    <td>{user.userName}</td>
                    <td><input type="checkbox" 
                               onChange={(e) => checkedChanged(e, user)}
                               defaultChecked={followedUserIds.includes(user.id)} />
                    </td>
                </tr>
            )}
            </tbody>
        </table>
            <button onClick={(e) => props.updateFollows(followedUserIds)}>Save Changes</button>
        </div>
    )
};