<template>
    <h1 id="tableLabel">GitHub User</h1>

    <input v-model="message" placeholder="Enter Username...">
    <button class="btn btn-primary" @click="searchForUser">Search</button>

    <p v-if="!searched">Type a name and click search to search the GitHub User</p>

    <div class="paging" v-if="searched">
        <p>Total Count: {{totalResults}}</p>
        <button v-bind:disabled="page === 1" class="btn btn-secondary" @click="previousPage">&lt;</button>
        <button v-bind:disabled="Math.ceil(totalResults/30) === page" class="btn btn-secondary" @click="nextPage">></button>
    </div>

    <table v-if="searched" class='table table-striped' aria-labelledby="tableLabel">
        <thead>
            <tr>
                <th></th>
                <th>Name</th>
                <th>Type</th>
                <th>Score</th>
                <th>Admin User</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="user of users" v-bind:key="user">
                <td><img :src="user.avatar_Url"></td>
                <td><a :href="user.html_Url"> {{ user.login }}</a></td>
                <td>{{ user.type }}</td>
                <td>{{ user.score }}</td>
                <td>{{ user.site_Admin }}</td>
            </tr>
        </tbody>
    </table>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "Home",
        data() {
            return {
                message: '',
                searched: false,
                users: [],
                totalResults: 0,
                page: 1,
            }
        },
        methods: {
            searchForUser() {
                axios.get('User', { params: { user: this.message, page: this.page} })
                    .then((response) => {
                        this.searched = true;
                        this.users = response.data.items;
                        this.totalResults = response.data.total_Count;
                    }).catch(function (error) {
                        alert(error);
                    });
            },
            nextPage() {
                this.page += 1;
                this.searchForUser();
            },
            previousPage() {
                this.page -= 1;
                this.searchForUser();
            },
        }
    }
</script>

<style scoped>
    img {
        width: 32px;
        height: 32px;
    }

    .paging {
        display: flex;
        align-items: baseline;
        justify-content: flex-end;
    }

    .paging > p, div{
        margin-right: 8px;
    }

    td {
        vertical-align: middle;
    }
</style>
