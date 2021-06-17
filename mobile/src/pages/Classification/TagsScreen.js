import React from 'react';
import { StyleSheet } from 'react-native';
import { Button, Layout } from '@ui-kitten/components';

export const TagsScreen = ({ route }) => {

  return (
      <Layout style={styles.layout}>
        {route.params.options?.map(text => <Button onPress={route.params.selectionHandler} appearance='outline' status='basic' style={styles.button}>{text}</Button>)}  
      </Layout>  
  );
};

const styles = StyleSheet.create({
  layout : {
    flex: 1, 
    justifyContent: 'center', 
  },
  button:{
    width:'100%'
  }
});

export default TagsScreen;