import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Table } from 'reactstrap';
import { fetchCandidates } from '../api';

export default class CandidateList extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = { list: [] };
    }

    async componentDidMount() {
        this.setState({
            list: await fetchCandidates(),
        })
    }

    render() {
        return <div>
            <h1>List of Candidates</h1>
            <Table>
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Skills</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.list.map(c => <tr key={c.id}>
                        <td>{c.firstName}</td>
                        <td>{c.lastName}</td>
                        <td>{c.skills.join(', ')}</td>
                    </tr>)}
                </tbody>
            </Table>
            <Button color='primary' tag={Link} to='/add'>Add Candidate</Button>
        </div>
    }
}