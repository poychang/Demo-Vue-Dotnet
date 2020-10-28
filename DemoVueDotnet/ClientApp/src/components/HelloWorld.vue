<template>
  <div class="hello">
    <h1>{{ msg }}</h1>

     <table v-show="contactsList.length" class="table-condensed" border="1">
            <thead class="navbar-header">
                <tr>
                    <th>姓名</th>
                    <th>电话号码</th>
                    <th>Email地址</th>
                    <th>操作</th>
                </tr>
                <tr v-for="contact in contactsList" :key="contact.id">
                    <td><input type="text" v-model="contact.name" /></td>
                    <td><input type="text" v-model="contact.phoneNo" /></td>
                    <td><input type="text" v-model="contact.emailAddress" /></td>
                    <td>
                        <div v-if="contact.id!=''">
                            <a href="#" v-on:click="updateContact(contact.id,contact.name,contact.phoneNo,contact.emailAddress)">修改</a>
                            <a href="#" v-on:click="deleteContactById(contact.id)">删除</a>
                        </div>
                        <div v-else>
                            <a href="#" v-on:click="addContact(contact.name,contact.phoneNo,contact.emailAddress)">添加</a>
                        </div>
                    </td>
                </tr>
            </thead>
        </table>
 
   
  </div>
</template>

<script>

import axios from 'axios'

export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },

  data() {
    return{
      contactsList : [],
    }      
  },

  mounted() {
      this.getAllContacts();
  },

  methods: {
      getAllContacts: function () {
          axios.get('https://localhost:44369/api/contacts')
          .then(
              (response) => {
                  this.contactsList = [];
                  for (var i = 0; i < response.data.length; i++) {
                      this.contactsList.push(response.data[i]);
                  }
                  this.contactsList.push({ id: "", name: "xxx", phoneNo: "123", emailAddress: "123@xxx" });
              },
              (response) => {
                  alert(response.status);
              })
          .catch(function (response) {
              alert(response);
          });
      },
      addContact: function (name, phoneno, emailaddress) {
          axios.post('https://localhost:44369/api/contacts',
              {  Name: name, Phoneno: phoneno, Emailaddress: emailaddress })
            .then(
                (response) => {
                  this.getAllContacts();
                  alert(response.status);
              }
          ).catch(function (response) {
              alert(response);
          });
      },
      updateContact: function (id, name, phoneno, emailaddress) {
          var Url = "https://localhost:44369/api/contacts/" + id;
          axios.put(Url,
              { Id : id, Name: name, PhoneNo: phoneno, EmailAddress: emailaddress })
            .then(                   
                (response) => {
                  this.getAllContacts();
                  alert(response.status);
              }
          ).catch(function (response) {
              alert(response);
          });
      },
      deleteContactById: function (id) {
          var Url = "https://localhost:44369/api/contacts/" + id;
          axios.delete(Url)
            .then(
                (response) => {
                  this.getAllContacts();
                  alert(response.status);
              }
          ).catch(function (response) {
              alert(response);
          });
      }
  }   

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
